using Abp.Application.Services.Dto;
using System;

namespace Hudayim.Uyelik.KullaniciKategorileris.Dto
{
	public class KullaniciKategorileriDto : EntityDto<int>
	{
		public long? UserId { get; set; }
		public string UserName { get; set; }
		public int? KategoriId { get; set; }
		public string KategoriAdi { get; set; }
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
