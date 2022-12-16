using Abp.Application.Services.Dto;
using System;

namespace Hudayim.Uyelik.Ulkes.Dto
{
	public class UlkeDto : EntityDto<int>
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

	}
}
