using Abp.Application.Services.Dto;

namespace Hudayim.Uyelik.Birims.Dto
{
	public class PagedBirimResultRequestDto : PagedResultRequestDto
	{
		public string Keyword { get; set; }
		public bool? IsActive { get; set; }

	}
}
