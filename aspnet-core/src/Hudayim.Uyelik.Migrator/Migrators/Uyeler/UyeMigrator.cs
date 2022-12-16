using Abp.Authorization.Users;
using EFCore.BulkExtensions;
using Hudayim.Uyelik.Authorization.Users;
using Hudayim.Uyelik.EntityFrameworkCore;
using Hudayim.Uyelik.Migrator.Data.EntityFramework.IlanBis;
using Hudayim.Uyelik.Migrator.Data.EntityFramework.Uyelik;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hudayim.Uyelik.Migrator.Migrators.Uyeler
{
	public class UyeMigrator : MigratorBase
	{
		public UyeMigrator(IBDBContext _dbContextIB, UyelikDbContext _dbContextUyelik, UyelikDBContext _dbContextUyelik2, Log log) : base(_dbContextIB, _dbContextUyelik, _dbContextUyelik2, log)
		{
		}

		public override void Migrate()
		{
			#region User
			Log.Write("Users Start");
			var source = dbContextUyelik2.HudayimUyeListesiExcel.ToList();
			var users = dbContextUyelik.Users.ToList();
			var ulke = dbContextUyelik.Ulkeler.Where(a => a.Ad == "Türkiye").FirstOrDefault();
			var iller = dbContextUyelik.Iller.Where(a => !a.IsDeleted).ToList();
			var ilceler = dbContextUyelik.Ilceler.Where(a => !a.IsDeleted).ToList();
			var get_user_role = dbContextUyelik.Roles.Where(a => a.Name == "Kullanıcı").FirstOrDefault();
			var get_admin_user = dbContextUyelik.Users.IgnoreQueryFilters().FirstOrDefault(u => u.TenantId == null && u.UserName == AbpUserBase.AdminUserName);

			if (source != null && source.Count > 0)
			{
				Log.Write($"Total {source.Count} Users found");

				var newListUsers = new List<User>();
				var newListUserRoles = new List<UserRole>();
				var newListUserAccounts = new List<UserAccount>();

				foreach (var item in source)
				{
					var il = string.IsNullOrEmpty(item.GuncelIl) == false ?
						iller.Where(a => a.Ad.Contains(item.GuncelIl) || a.Ad.Contains(item.GuncelIl.ToLowerInvariant()) || a.Ad.Contains(item.GuncelIl.ToUpperInvariant())).FirstOrDefault() :
						null;

					var ilce = string.IsNullOrEmpty(item.GuncelIlce) == false ?
						ilceler.Where(a => a.Ad.Contains(item.GuncelIlce) || a.Ad.Contains(item.GuncelIlce.ToLowerInvariant()) || a.Ad.Contains(item.GuncelIlce.ToUpperInvariant())).FirstOrDefault() :
						null;

					var user = new User
					{
						TenantId = null,
						UserName = !string.IsNullOrEmpty(item.Adi) && !string.IsNullOrEmpty(item.Soyadi) ? $"{StringReplace(item.Adi.ToLower())}{StringReplace(item.Soyadi.ToLower())}" :
									!string.IsNullOrEmpty(item.Adi) || !string.IsNullOrEmpty(item.Soyadi) ? $"{StringReplace(item.Adi.ToLower())}{StringReplace(item.Soyadi.ToLower())}" :
									!string.IsNullOrEmpty(item.GuncelMail) ? item.GuncelMail : " - ",
						Surname = item.Soyadi ?? "",
						EmailAddress = item.GuncelMail ?? "-",
						IsEmailConfirmed = true,
						IsActive = true
					};

					user.Password = new PasswordHasher<User>(new OptionsWrapper<PasswordHasherOptions>(new PasswordHasherOptions())).HashPassword(user, "123qwe");
					user.SetNormalizedNames();
					user.Name = item.Adi ?? "";
					user.NormalizedEmailAddress = item.GuncelMail?.ToUpperInvariant() ?? "-";
					user.PhoneNumber = item.GuncelSabitTelefon;
					user.IkinciTelefon = item.GuncelGsmTelefon?.ToString() ?? "-";
					user.KvkkOnayliMi = false;
					user.MezuniyetYili = item.MezuniyetYili.HasValue == true ? item.MezuniyetYili : 0;
					user.MezunOlduguOkul = item.MezunOlduguOkul;
					user.MezunOlduguBolum = item.MezunOlduguBolum;
					user.CalistigiKurum = item.GuncelCalisilanKurum;
					user.CalistigiGorev = item.GuncelGorevi;
					user.CalistigiPozisyon = item.GuncelPozisyonu;
					user.CalistigiDurumAciklama = $"{item.GuncelCalisilanKurum}/{item.GuncelGorevi}/{item.GuncelPozisyonu}";
					user.CreationTime = item.KayitTarihi.HasValue == true ? (DateTime)item.KayitTarihi : DateTime.Now;
					user.CreatorUserId = get_admin_user.Id;
					user.LastModificationTime = null;
					user.LastModifierUserId = null;
					user.UlkeId = ulke.Id;
					user.IlId = il != null ? il.Id : new Nullable<int>();
					user.IlceId = ilce != null ? ilce.Id : new Nullable<int>();
					user.Adres = item.Adres;
					user.IsDeleted = false;
					user.IsEmailConfirmed = true;
					user.IsLockoutEnabled = true;
					user.IsPhoneNumberConfirmed = true;
					user.IsTwoFactorEnabled = false;
					user.UyelikBaslangicTarihi = item.KayitTarihi.HasValue == true ? (DateTime)item.KayitTarihi : DateTime.Now;
					user.UyelikBitisTarihi = item.KayitTarihi.HasValue == true ? (DateTime)item.KayitTarihi.Value.AddYears(1) : DateTime.Now.AddYears(1);

					newListUsers.Add(user);
				}

				if (newListUsers != null && newListUsers.Count > 0)
					dbContextUyelik.BulkInsert(newListUsers);
			}
			#endregion

			var listA = new List<long>();
			listA.Add(1);
			listA.Add(2);

			var target_users = dbContextUyelik2.AbpUsers.Where(a => !listA.Contains(a.Id)).ToList();

			#region AbpUserRoles
			var listUserRoles = new List<UserRole>();

			foreach (var item in target_users)
			{
				UserRole targetUserRoles = new UserRole();

				targetUserRoles.CreationTime = DateTime.Now;
				targetUserRoles.CreatorUserId = get_admin_user.Id;
				targetUserRoles.UserId = item.Id;
				targetUserRoles.RoleId = get_user_role.Id;

				listUserRoles.Add(targetUserRoles);
			}

			Log.Write($"AbpUserRoles Inserting");
			if (listUserRoles != null && listUserRoles.Count > 0)
				dbContextUyelik.BulkInsert(listUserRoles);
			Log.Write($"AbpUserRoles Inserted");
			#endregion AbpUserRoles
			#region AbpUserAccount
			var listUserAccount = new List<UserAccount>();

			foreach (var item in target_users)
			{
				UserAccount targetUserAccount = new UserAccount();

				targetUserAccount.CreationTime = DateTime.Now;
				targetUserAccount.CreatorUserId = get_admin_user.Id;
				targetUserAccount.LastModificationTime = DateTime.Now;
				targetUserAccount.LastModifierUserId = get_admin_user.Id;
				targetUserAccount.UserId = item.Id;
				targetUserAccount.IsDeleted = false;
				targetUserAccount.UserName = item.UserName;
				targetUserAccount.EmailAddress = item.EmailAddress;

				listUserAccount.Add(targetUserAccount);
			}

			Log.Write($"AbpUserAccount Inserting");


			if (listUserAccount != null && listUserAccount.Count > 0)
				dbContextUyelik.BulkInsert(listUserAccount);

			Log.Write($"AbpUserAccount Inserted");
			#endregion AbpUserAccount
		}
		public string StringReplace(string text)
		{
			text = text.Replace("İ", "I");
			text = text.Replace("i", "i");
			text = text.Replace("ı", "i");
			text = text.Replace("Ğ", "G");
			text = text.Replace("ğ", "g");
			text = text.Replace("Ö", "O");
			text = text.Replace("ö", "o");
			text = text.Replace("Ü", "U");
			text = text.Replace("ü", "u");
			text = text.Replace("Ş", "S");
			text = text.Replace("ş", "s");
			text = text.Replace("Ç", "C");
			text = text.Replace("ç", "c");
			text = text.Replace(" ", "_");
			return text;
		}
	}
}
