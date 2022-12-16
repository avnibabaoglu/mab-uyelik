using Abp.Application.Services.Dto;
using System;

namespace Hudayim.Uyelik.Ils.Dto
{
	public class PagedIlResultRequestDto : PagedResultRequestDto
	{
		public int Id { get; set; }
		public string Keyword { get; set; }
		public bool? IsDeleted { get; set; }
		public int? UlkeId { get; set; }

	}
}
