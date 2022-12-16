using Hudayim.Uyelik.Gelirs.Dto;
using Hudayim.Uyelik.Users.Dto;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Hudayim.Uyelik.Web.Models.Gelirs
{
	public class GelirViewModel
	{
		public IReadOnlyList<GelirDto> Gelirler { get; set; }
		public GelirDto GelirDto { get; set; }
		public UserDto UserDto { get; set; }
		public CreateGelirDto CreateGelirDto { get; set; }
		public EditGelirDto EditGelirDto { get; set; }

		public SelectList LGelirTurleri { get; set; }
		public SelectList LDonemler { get; set; }
		public SelectList LKullanicilar { get; set; }

	}
}
