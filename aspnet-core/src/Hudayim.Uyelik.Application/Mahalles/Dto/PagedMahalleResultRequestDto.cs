using Abp.Application.Services.Dto;

namespace Hudayim.Uyelik.Mahalles.Dto
{
	public class PagedMahalleResultRequestDto : PagedResultRequestDto
	{
		public int Id { get; set; }
		public string Keyword { get; set; }
		public bool? IsDeleted { get; set; }
		public int? IlceId { get; set; }
	}
}
