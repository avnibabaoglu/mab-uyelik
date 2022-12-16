using Hudayim.Uyelik.Firmas.Dto;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Hudayim.Uyelik.Web.Models.Firmas
{
	public class FirmaViewModel
	{
		public IReadOnlyList<FirmaDto> Firmalar { get; set; }
		public SelectList LIller { get; set; }
		public SelectList LKategoriler { get; set; }

	}
}
