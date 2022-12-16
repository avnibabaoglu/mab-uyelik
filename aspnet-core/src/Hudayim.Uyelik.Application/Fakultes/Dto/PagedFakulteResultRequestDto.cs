using Abp.Application.Services.Dto;

namespace Hudayim.Uyelik.Fakultes.Dto
{
	public class PagedFakulteResultRequestDto : PagedResultRequestDto
	{
		public int Id { get; set; }
		public string Keyword { get; set; }
		public bool? IsActive { get; set; }
		public bool? IsDeleted { get; set; }
		public int? UniversiteId { get; set; }

	}
}
