using Hudayim.Uyelik.Donems.Dto;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hudayim.Uyelik.Web.Models.Donems
{
	public class EditDonemModalViewModel
	{
		public DonemDto DonemDto { get; set; }

		public SelectList LDonemTurleri { get; set; }
	}
}
