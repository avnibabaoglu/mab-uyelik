using Hudayim.Uyelik.Entities.Enums;
using System;

namespace Hudayim.Uyelik.Donems.Dto
{
	public class CreateDonemDto
	{
		public string Ad { get; set; }
		public int SiraNo { get; set; }
		public DateTime BaslangicTarihi { get; set; }
		public DateTime BitisTarihi { get; set; }
		public bool AktifMi { get; set; }
		public DonemTuruEnum DonemTuru { get; set; }
		public DateTime? CreationTime { get; set; }
		public long? CreatorUserId { get; set; }
		public DateTime? LastModificationTime { get; set; }
		public long? LastModifierUserId { get; set; }
		public bool? IsDeleted { get; set; }
		public long? DeleterUserId { get; set; }
		public DateTime? DeletionTime { get; set; }

	}
}
