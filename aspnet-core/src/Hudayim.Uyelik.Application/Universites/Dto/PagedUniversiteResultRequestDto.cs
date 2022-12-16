using Abp.Application.Services.Dto;
using System;

namespace Hudayim.Uyelik.Universites.Dto
{
	public class PagedUniversiteResultRequestDto : PagedResultRequestDto
	{
		public string Keyword { get; set; }
		public bool? IsActive { get; set; }

	}
}
