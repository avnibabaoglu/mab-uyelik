using System;
using System.ComponentModel.DataAnnotations;

namespace Hudayim.Uyelik.Migrator.Data.EntityFramework.Uyelik.Models
{
	public partial class AbpUsers
	{
		public AbpUsers()
		{
		}

		public long Id { get; set; }
		public DateTime CreationTime { get; set; }
		public long? CreatorUserId { get; set; }
		public DateTime? LastModificationTime { get; set; }
		public long? LastModifierUserId { get; set; }
		public bool IsDeleted { get; set; }
		public long? DeleterUserId { get; set; }
		public DateTime? DeletionTime { get; set; }
		[StringLength(64)]
		public string AuthenticationSource { get; set; }
		[Required]
		[StringLength(256)]
		public string UserName { get; set; }
		public int? TenantId { get; set; }
		[Required]
		[StringLength(256)]
		public string EmailAddress { get; set; }
		[Required]
		[StringLength(64)]
		public string Name { get; set; }
		[Required]
		[StringLength(64)]
		public string Surname { get; set; }
		[Required]
		[StringLength(128)]
		public string Password { get; set; }
		[StringLength(328)]
		public string EmailConfirmationCode { get; set; }
		[StringLength(328)]
		public string PasswordResetCode { get; set; }
		public DateTime? LockoutEndDateUtc { get; set; }
		public int AccessFailedCount { get; set; }
		public bool IsLockoutEnabled { get; set; }
		[StringLength(32)]
		public string PhoneNumber { get; set; }
		public bool IsPhoneNumberConfirmed { get; set; }
		[StringLength(128)]
		public string SecurityStamp { get; set; }
		public bool IsTwoFactorEnabled { get; set; }
		public bool IsEmailConfirmed { get; set; }
		public bool IsActive { get; set; }
		[Required]
		[StringLength(256)]
		public string NormalizedUserName { get; set; }
		[Required]
		[StringLength(256)]
		public string NormalizedEmailAddress { get; set; }
		[StringLength(128)]
		public string ConcurrencyStamp { get; set; }
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
	}
}
