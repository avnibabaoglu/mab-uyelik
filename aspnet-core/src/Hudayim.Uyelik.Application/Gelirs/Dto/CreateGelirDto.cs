using System;

namespace Hudayim.Uyelik.Gelirs.Dto
{
	public class CreateGelirDto
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
		public DateTime? CreationTime { get; set; }
		public long? CreatorUserId { get; set; }
		public DateTime? LastModificationTime { get; set; }
		public long? LastModifierUserId { get; set; }
		public bool? IsDeleted { get; set; }
		public long? DeleterUserId { get; set; }
		public DateTime? DeletionTime { get; set; }

	}
}
