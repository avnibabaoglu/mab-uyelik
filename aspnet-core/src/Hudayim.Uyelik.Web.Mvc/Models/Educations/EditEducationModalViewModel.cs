using Hudayim.Uyelik.Bolums.Dto;
using Hudayim.Uyelik.Fakultes.Dto;
using Hudayim.Uyelik.Universites.Dto;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hudayim.Uyelik.Web.Models.Educations
{
	public class EditEducationModalViewModel
	{
		public UniversiteDto UniversiteDto { get; set; }
		public FakulteDto FakulteDto { get; set; }
		public BolumDto BolumDto { get; set; }

		public SelectList LUniversiteler { get; set; }
		public SelectList LFakulteler { get; set; }
		public SelectList LBolumler { get; set; }

	}
}
