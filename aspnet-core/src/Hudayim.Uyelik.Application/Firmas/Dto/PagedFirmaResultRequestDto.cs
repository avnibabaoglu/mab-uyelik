using Abp.Application.Services.Dto;

namespace Hudayim.Uyelik.Firmas.Dto
{
	public class PagedFirmaResultRequestDto : PagedResultRequestDto
	{
		public int Id { get; set; }
		public string Keyword { get; set; }
		public bool? IsActive { get; set; }
		public bool? IsDeleted { get; set; }
		public int? IlId { get; set; }
		public int? KategoriId { get; set; }

	}
}
