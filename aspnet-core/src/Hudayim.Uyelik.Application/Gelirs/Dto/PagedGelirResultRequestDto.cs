using Abp.Application.Services.Dto;

namespace Hudayim.Uyelik.Gelirs.Dto
{
	public class PagedGelirResultRequestDto : PagedResultRequestDto
	{
		public string Keyword { get; set; }
		public bool? IsActive { get; set; }

	}
}
