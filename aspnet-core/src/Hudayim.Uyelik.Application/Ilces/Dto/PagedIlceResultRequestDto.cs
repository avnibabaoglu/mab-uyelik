using Abp.Application.Services.Dto;
using System;

namespace Hudayim.Uyelik.Ilces.Dto
{
	public class PagedIlceResultRequestDto : PagedResultRequestDto
	{
		public int Id { get; set; }
		public string Keyword { get; set; }
		public bool? IsDeleted { get; set; }
		public int? IlId { get; set; }

	}
}
