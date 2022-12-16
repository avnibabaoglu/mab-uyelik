using Abp.Application.Services.Dto;
using System;

namespace Hudayim.Uyelik.Kampanyas.Dto
{
	public class PagedKampanyaResultRequestDto : PagedResultRequestDto
	{
		public int Id { get; set; }
		public string Keyword { get; set; }
		public bool? IsActive { get; set; }
		public bool? IsDeleted { get; set; }
		public int? FirmaId { get; set; }

	}
}
