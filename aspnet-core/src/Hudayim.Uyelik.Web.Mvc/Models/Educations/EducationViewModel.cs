using Hudayim.Uyelik.Bolums.Dto;
using Hudayim.Uyelik.Fakultes.Dto;
using Hudayim.Uyelik.Universites.Dto;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Hudayim.Uyelik.Web.Models.Educations
{
	public class EducationViewModel
	{
		public IReadOnlyList<UniversiteDto> Universiteler { get; set; }
		public IReadOnlyList<FakulteDto> Fakulteler { get; set; }
		public IReadOnlyList<BolumDto> Bolumler { get; set; }

		public SelectList LUniversiteler { get; set; }
		public SelectList LFakulteler { get; set; }
		public SelectList LBolumler { get; set; }

	}
}
