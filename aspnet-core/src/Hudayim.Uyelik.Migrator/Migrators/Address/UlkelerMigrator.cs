using EFCore.BulkExtensions;
using Hudayim.Uyelik.Entities;
using Hudayim.Uyelik.EntityFrameworkCore;
using Hudayim.Uyelik.Migrator.Data.EntityFramework.IlanBis;
using Hudayim.Uyelik.Migrator.Data.EntityFramework.Uyelik;
using Hudayim.Uyelik.Migrator.Migrators;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hudayim.Uyelik.Migrator
{
	public class UlkelerMigrator : MigratorBase
	{
		public UlkelerMigrator(IBDBContext _dbContextIB, UyelikDbContext _dbContextUyelik, UyelikDBContext _dbContextUyelik2, Log log) : base(_dbContextIB, _dbContextUyelik, _dbContextUyelik2, log)
		{

		}

		public override void Migrate()
		{
			Log.Write("Countries Start");
			var sourceCountries = dbContextUyelik2.UlkelerListesiExcel.ToList();

			#region Country
			if (sourceCountries != null && sourceCountries.Count > 0)
			{
				Log.Write($"Total {sourceCountries.Count} countries");
				var newCountryList = new List<Ulke>();

				int countryCount = 3;
				foreach (var item in sourceCountries)
				{
					Ulke ulke = new Ulke();

					ulke.Ad = item.Ad.ToUpper();
					ulke.SiraNo = countryCount;
					ulke.CreationTime = DateTime.Now;
					ulke.IsDeleted = false;
					ulke.SourceId = item.Id;

					countryCount++;

					newCountryList.Add(ulke);
				}

				if (newCountryList != null)
					dbContextUyelik.BulkInsert(newCountryList);

			}
			#endregion

			Log.Write("Countries End");
		}
	}
}