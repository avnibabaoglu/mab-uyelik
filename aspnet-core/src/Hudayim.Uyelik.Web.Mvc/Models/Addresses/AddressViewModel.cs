using Hudayim.Uyelik.Ilces.Dto;
using Hudayim.Uyelik.Ils.Dto;
using Hudayim.Uyelik.Mahalles.Dto;
using Hudayim.Uyelik.Ulkes.Dto;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Hudayim.Uyelik.Web.Models.Addresses
{
	public class AddressViewModel
	{
		public IReadOnlyList<UlkeDto> Ulkeler { get; set; }
		public IReadOnlyList<IlDto> Iller { get; set; }
		public IReadOnlyList<IlceDto> Ilceler { get; set; }
		public IReadOnlyList<MahalleDto> Mahalleler { get; set; }

		public SelectList LUlkeler { get; set; }
		public SelectList LIller { get; set; }
		public SelectList LIlceler { get; set; }
		public SelectList LMahalleler { get; set; }

	}
}
