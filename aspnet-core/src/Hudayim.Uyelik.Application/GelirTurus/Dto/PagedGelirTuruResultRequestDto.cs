using Abp.Application.Services.Dto;

namespace Hudayim.Uyelik.GelirTurus.Dto
{
	public class PagedGelirTuruResultRequestDto : PagedResultRequestDto
	{
		public string Keyword { get; set; }
		public bool? IsActive { get; set; }

	}
}
