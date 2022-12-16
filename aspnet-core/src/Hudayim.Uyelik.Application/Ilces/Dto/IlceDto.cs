using Abp.Application.Services.Dto;
using System;

namespace Hudayim.Uyelik.Ilces.Dto
{
	public class IlceDto : EntityDto<int>
	{
		public string Ad { get; set; }
		public int SiraNo { get; set; }
		public DateTime? CreationTime { get; set; }
		public long? CreatorUserId { get; set; }
		public DateTime? LastModificationTime { get; set; }
		public long? LastModifierUserId { get; set; }
		public bool? IsDeleted { get; set; }
		public long? DeleterUserId { get; set; }
		public DateTime? DeletionTime { get; set; }

		public int? UlkeId { get; set; }
		public string UlkeAdi { get; set; }

		public int? IlId { get; set; }
		public string IlAdi { get; set; }

	}
}
