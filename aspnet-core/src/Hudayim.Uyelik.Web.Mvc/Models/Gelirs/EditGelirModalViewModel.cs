using Hudayim.Uyelik.Gelirs.Dto;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hudayim.Uyelik.Web.Models.Gelirs
{
	public class EditGelirModalViewModel
	{
		public GelirDto GelirDto { get; set; }

		public SelectList LGelirTurleri { get; set; }
		public SelectList LDonemler { get; set; }
		public SelectList LKullanicilar { get; set; }
	}
}
