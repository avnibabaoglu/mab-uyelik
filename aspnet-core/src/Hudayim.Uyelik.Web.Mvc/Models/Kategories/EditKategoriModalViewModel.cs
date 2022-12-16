using Hudayim.Uyelik.Kategories.Dto;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hudayim.Uyelik.Web.Models.Kategories
{
	public class EditKategoriModalViewModel
	{
		public SelectList LKategorTurleri { get; set; }
		public KategoriDto KategoriDto { get; set; }
	}
}
