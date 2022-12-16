using Hudayim.Uyelik.Kategories.Dto;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Hudayim.Uyelik.Web.Models.Kategories
{
	public class KategoriViewModel
	{
		public SelectList LKategorTurleri { get; set; }
		public IReadOnlyList<KategoriDto> Kategoriler { get; set; }
	}
}
