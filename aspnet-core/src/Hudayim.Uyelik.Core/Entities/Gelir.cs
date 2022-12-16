using Abp.Domain.Entities.Auditing;
using Hudayim.Uyelik.Authorization.Users;
using System;

namespace Hudayim.Uyelik.Entities
{
	public class Gelir : FullAuditedEntity
	{
		public string Ad { get; set; }
		public decimal Tutar { get; set; }
		public string Not { get; set; }
		public DateTime? OdemeTarihi { get; set; }
		public DateTime? SonOdemeTarihi { get; set; }
		public int? SiraNo { get; set; }
		public bool AktifMi { get; set; }

		public long UserId { get; set; }
		public int? DonemId { get; set; }
		public int? GelirTuruId { get; set; }

		public virtual User User { get; set; }
		public virtual Donem Donem { get; set; }
		public virtual GelirTuru GelirTuru { get; set; }

	}
}
