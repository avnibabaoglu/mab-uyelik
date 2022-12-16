using Abp.Authorization.Users;
using Abp.Extensions;
using Hudayim.Uyelik.Entities;
using System;
using System.Collections.Generic;

namespace Hudayim.Uyelik.Authorization.Users
{
	public class User : AbpUser<User>
	{
		public const string DefaultPassword = "123qwe";

		public static string CreateRandomPassword()
		{
			return Guid.NewGuid().ToString("N").Truncate(16);
		}

		public static User CreateTenantAdminUser(int tenantId, string emailAddress)
		{
			var user = new User
			{
				TenantId = tenantId,
				UserName = AdminUserName,
				Name = AdminUserName,
				Surname = AdminUserName,
				EmailAddress = emailAddress,
				Roles = new List<UserRole>()
			};

			user.SetNormalizedNames();

			return user;
		}

		public string MezunOlduguOkul { get; set; }
		public string MezunOlduguBolum { get; set; }
		public int? MezuniyetYili { get; set; }
		public string CalistigiKurum { get; set; }
		public string CalistigiGorev { get; set; }
		public string CalistigiPozisyon { get; set; }
		public string CalistigiDurumAciklama { get; set; }
		public string IkinciTelefon { get; set; }
		public string Adres { get; set; }
		public bool? KvkkOnayliMi { get; set; }
		public DateTime UyelikBaslangicTarihi { get; set; }
		public DateTime UyelikBitisTarihi { get; set; }
		public int? DonemId { get; set; }
		public int? BirimId { get; set; }
		public int? UlkeId { get; set; }
		public int? IlId { get; set; }
		public int? IlceId { get; set; }
		public int? MahalleId { get; set; }
		public int? UniversiteId { get; set; }
		public int? FakulteId { get; set; }
		public int? BolumId { get; set; }
		public int? MeslekId { get; set; }
		public string ProfilFotografYolu { get; set; }
		public string ProfilFotografAdi { get; set; }
		public string Not { get; set; }
		public virtual Donem Donem { get; set; }
		public virtual Birim Birim { get; set; }
		public virtual Ulke Ulke { get; set; }
		public virtual Il Il { get; set; }
		public virtual Ilce Ilce { get; set; }
		public virtual Mahalle Mahalle { get; set; }
		public virtual Universite Universite { get; set; }
		public virtual Fakulte Fakulte { get; set; }
		public virtual Bolum Bolum { get; set; }
		public virtual Meslek Meslek { get; set; }
		public virtual ICollection<Gelir> Gelirler { get; set; }
		public virtual ICollection<KullaniciKategorileri> KullaniciKategorileri { get; set; }

	}
}
