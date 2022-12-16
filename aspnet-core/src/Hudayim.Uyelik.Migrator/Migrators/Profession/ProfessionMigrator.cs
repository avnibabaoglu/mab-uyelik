using Abp.Authorization.Users;
using EFCore.BulkExtensions;
using Hudayim.Uyelik.EntityFrameworkCore;
using Hudayim.Uyelik.Migrator.Data.EntityFramework.IlanBis;
using Hudayim.Uyelik.Migrator.Data.EntityFramework.Uyelik;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hudayim.Uyelik.Migrator.Migrators.Meslek
{
	public class ProfessionMigrator : MigratorBase
	{
		public ProfessionMigrator(IBDBContext _dbContextIB, UyelikDbContext _dbContextUyelik, UyelikDBContext _dbContextUyelik2, Log log) : base(_dbContextIB, _dbContextUyelik, _dbContextUyelik2, log)
		{
		}

		public override void Migrate()
		{
			Log.Write("Meslek Start");
			var source = dbContextUyelik2.MesleklerListesi.ToList();
			var get_admin_user = dbContextUyelik.Users.IgnoreQueryFilters().FirstOrDefault(u => u.TenantId == null && u.UserName == AbpUserBase.AdminUserName);

			if (source != null && source.Count > 0)
			{
				Log.Write($"Total {source.Count} Meslek found");

				var newList = new List<Entities.Meslek>();

				int count = 1;
				foreach (var item in source)
				{
					Entities.Meslek meslek = new Entities.Meslek();

					meslek.Ad = item.Ad;
					meslek.Kod = item.Kod;
					meslek.SiraNo = count;
					meslek.AktifMi = true;
					meslek.CreationTime = DateTime.Now;
					meslek.CreatorUserId = get_admin_user.Id;
					meslek.IsDeleted = false;

					newList.Add(meslek);

					count++;
				}

				if (newList != null && newList.Count > 0)
					dbContextUyelik.BulkInsert(newList);

				Log.Write("Meslek End");

			}
		}
	}
}
