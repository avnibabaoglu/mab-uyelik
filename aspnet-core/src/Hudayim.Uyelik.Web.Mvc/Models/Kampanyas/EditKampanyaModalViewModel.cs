using Hudayim.Uyelik.Kampanyas.Dto;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hudayim.Uyelik.Web.Models.Kampanyas
{
	public class EditKampanyaModalViewModel
	{
		public KampanyaDto KampanyaDto { get; set; }
		public SelectList LFirmalar{ get; set; }

	}
}
