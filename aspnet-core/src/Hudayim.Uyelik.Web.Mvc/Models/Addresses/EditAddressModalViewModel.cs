using Hudayim.Uyelik.Ilces.Dto;
using Hudayim.Uyelik.Ils.Dto;
using Hudayim.Uyelik.Mahalles.Dto;
using Hudayim.Uyelik.Ulkes.Dto;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hudayim.Uyelik.Web.Models.Addresses
{
	public class EditAddressModalViewModel
	{
		public UlkeDto UlkeDto { get; set; }
		public IlDto IlDto { get; set; }
		public IlceDto IlceDto { get; set; }
		public MahalleDto MahalleDto { get; set; }

		public SelectList LUlkeler { get; set; }
		public SelectList LIller { get; set; }
		public SelectList LIlceler { get; set; }
		public SelectList LMahalleler { get; set; }

	}
}
