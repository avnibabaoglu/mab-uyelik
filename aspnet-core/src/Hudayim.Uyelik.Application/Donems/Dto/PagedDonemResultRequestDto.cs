using Abp.Application.Services.Dto;
using Hudayim.Uyelik.Entities.Enums;

namespace Hudayim.Uyelik.Donems.Dto
{
	public class PagedDonemResultRequestDto : PagedResultRequestDto
	{
		public string Keyword { get; set; }
		public bool? IsActive { get; set; }
		public DonemTuruEnum? DonemTuru { get; set; }

	}
}
