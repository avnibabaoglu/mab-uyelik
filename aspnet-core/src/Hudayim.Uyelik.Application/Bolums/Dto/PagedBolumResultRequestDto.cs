using Abp.Application.Services.Dto;
using System;

namespace Hudayim.Uyelik.Bolums.Dto
{
	public class PagedBolumResultRequestDto : PagedResultRequestDto
	{
		public int Id { get; set; }
		public string Keyword { get; set; }
		public bool? IsActive { get; set; }
		public bool? IsDeleted { get; set; }
		public int? UniversiteId { get; set; }
		public int? FakulteId { get; set; }

	}
}
