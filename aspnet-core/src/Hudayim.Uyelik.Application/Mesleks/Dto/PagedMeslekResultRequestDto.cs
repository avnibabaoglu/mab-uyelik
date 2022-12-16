using Abp.Application.Services.Dto;

namespace Hudayim.Uyelik.Mesleks.Dto
{
	public class PagedMeslekResultRequestDto : PagedResultRequestDto
	{
		public string Keyword { get; set; }
		public bool? IsActive { get; set; }

	}
}
