using System;

namespace Hudayim.Uyelik.KullaniciKategorileris.Dto
{
	public class CreateKullaniciKategorileriDto
	{
		public long? UserId { get; set; }
		public int? KategoriId { get; set; }
		public string Description { get; set; }
		public DateTime? CreationTime { get; set; }
		public long? CreatorUserId { get; set; }
		public DateTime? LastModificationTime { get; set; }
		public long? LastModifierUserId { get; set; }
		public bool? IsDeleted { get; set; }
		public long? DeleterUserId { get; set; }
		public DateTime? DeletionTime { get; set; }

	}
}
