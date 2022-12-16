using Hudayim.Uyelik.Donems.Dto;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Hudayim.Uyelik.Web.Models.Donems
{
	public class DonemViewModel
	{
		public IReadOnlyList<DonemDto> Donemler{ get; set; }

		public SelectList LDonemTurleri { get; set; }
	}
}
