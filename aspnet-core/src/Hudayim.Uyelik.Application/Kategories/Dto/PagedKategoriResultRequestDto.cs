using Abp.Application.Services.Dto;
using Hudayim.Uyelik.Entities.Enums;

namespace Hudayim.Uyelik.Kategories.Dto
{
	public class PagedKategoriResultRequestDto : PagedResultRequestDto
	{
		public string Keyword { get; set; }
		public bool? IsActive { get; set; }
		public KategoriTuruEnum? KategoriTuru { get; set; }

	}
}
