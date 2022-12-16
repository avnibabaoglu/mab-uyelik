using Abp.Application.Services.Dto;
using System;

namespace Hudayim.Uyelik.Bolums.Dto
{
	public class BolumDto : EntityDto<int>
	{
		public string Ad { get; set; }
		public int? SiraNo { get; set; }
		public bool AktifMi { get; set; }
		public int? SourceId { get; set; }
		public int? FakulteId { get; set; }
		public string FakulteAdi { get; set; }
		public int? UniversiteId { get; set; }
		public string UniversiteAdi { get; set; }
		public DateTime? CreationTime { get; set; }
		public long? CreatorUserId { get; set; }
		public DateTime? LastModificationTime { get; set; }
		public long? LastModifierUserId { get; set; }
		public bool? IsDeleted { get; set; }
		public long? DeleterUserId { get; set; }
		public DateTime? DeletionTime { get; set; }

	}
}
