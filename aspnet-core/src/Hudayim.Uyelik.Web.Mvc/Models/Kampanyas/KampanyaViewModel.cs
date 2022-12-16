using Abp.Application.Services.Dto;
using Hudayim.Uyelik.Kampanyas.Dto;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Hudayim.Uyelik.Web.Models.Kampanyas
{
	public class KampanyaViewModel
	{
		public IReadOnlyList<KampanyaDto> Kampanyalar { get; set; }
		public SelectList LFirmalar { get; set; }
		public List<NameValueDto> LFirmaKategoriler { get; set; }

	}
}
