using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Auditing;
using Abp.Authorization.Users;
using Abp.AutoMapper;
using Abp.Runtime.Validation;
using Hudayim.Uyelik.Authorization.Users;

namespace Hudayim.Uyelik.Users.Dto
{
	[AutoMapTo(typeof(User))]
	public class CreateUserDto : IShouldNormalize
	{
		[Required]
		[StringLength(AbpUserBase.MaxUserNameLength)]
		public string UserName { get; set; }

		[Required]
		[StringLength(AbpUserBase.MaxNameLength)]
		public string Name { get; set; }

		[Required]
		[StringLength(AbpUserBase.MaxSurnameLength)]
		public string Surname { get; set; }

		[Required]
		[EmailAddress]
		[StringLength(AbpUserBase.MaxEmailAddressLength)]
		public string EmailAddress { get; set; }

		public bool IsActive { get; set; }

		public string[] RoleNames { get; set; }

		[Required]
		[StringLength(AbpUserBase.MaxPlainPasswordLength)]
		[DisableAuditing]
		public string Password { get; set; }

		public void Normalize()
		{
			if (RoleNames == null)
			{
				RoleNames = new string[0];
			}

			if (KategoriIds == null)
			{
				KategoriIds = new string[0];
			}
		}
		public DateTime CreationTime { get; set; }
		public string MezunOlduguOkul { get; set; }
		public string MezunOlduguBolum { get; set; }
		public int? MezuniyetYili { get; set; }
		public string CalistigiDurumAciklama { get; set; }
		public string CalistigiKurum { get; set; }
		public string CalistigiGorev { get; set; }
		public string CalistigiPozisyon { get; set; }
		public string PhoneNumber { get; set; }
		public string IkinciTelefon { get; set; }
		public string Adres { get; set; }
		public bool? KvkkOnayliMi { get; set; }
		public DateTime? UyelikBaslangicTarihi { get; set; }
		public DateTime? UyelikBitisTarihi { get; set; }
		public string[] KategoriIds { get; set; }
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

	}
}
