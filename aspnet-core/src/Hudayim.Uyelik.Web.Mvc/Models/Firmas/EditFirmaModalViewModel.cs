using Hudayim.Uyelik.Firmas.Dto;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hudayim.Uyelik.Web.Models.Firmas
{
	public class EditFirmaModalViewModel
	{
		public FirmaDto FirmaDto { get; set; }
		public SelectList LIller { get; set; }
		public SelectList LKategoriler { get; set; }

	}
}
