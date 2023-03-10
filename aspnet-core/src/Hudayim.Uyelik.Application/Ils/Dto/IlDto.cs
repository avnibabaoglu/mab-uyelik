using Abp.Application.Services.Dto;
using System;

namespace Hudayim.Uyelik.Ils.Dto
{
	public class IlDto : EntityDto<int>
	{
		public string Ad { get; set; }
		public string PlakaKodu { get; set; }
		public int SiraNo { get; set; }
		public int? UlkeId { get; set; }
		public string UlkeAdi { get; set; }
		public DateTime? CreationTime { get; set; }
		public long? CreatorUserId { get; set; }
		public DateTime? LastModificationTime { get; set; }
		public long? LastModifierUserId { get; set; }
		public bool? IsDeleted { get; set; }
		public long? DeleterUserId { get; set; }
		public DateTime? DeletionTime { get; set; }

	}
}
