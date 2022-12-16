using System;

namespace Hudayim.Uyelik.Mahalles.Dto
{
	public class CreateMahalleDto
	{
		public string Ad { get; set; }
		public int SiraNo { get; set; }
		public int? IlceId { get; set; }
		public DateTime? CreationTime { get; set; }
		public long? CreatorUserId { get; set; }
		public DateTime? LastModificationTime { get; set; }
		public long? LastModifierUserId { get; set; }
		public bool? IsDeleted { get; set; }
		public long? DeleterUserId { get; set; }
		public DateTime? DeletionTime { get; set; }

	}
}
