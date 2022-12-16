using Hudayim.Uyelik.Roles.Dto;
using Hudayim.Uyelik.Users.Dto;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace Hudayim.Uyelik.Web.Models.Users
{
	public class UserViewModel
	{
		public UserDto User { get; set; }
		public IReadOnlyList<RoleDto> Roles { get; set; }

		public bool UserIsInRole(RoleDto role)
		{
			return User.RoleNames != null && User.RoleNames.Any(r => r == role.NormalizedName);
		}

		public SelectList LKullaniciKategoriler { get; set; }
		public SelectList LUlkeler { get; set; }
		public SelectList LIller { get; set; }
		public SelectList LIlceler { get; set; }
		public SelectList LMahalleler { get; set; }
		public SelectList LKategoriler { get; set; }
		public SelectList LDonemler { get; set; }
		public SelectList LBirimler { get; set; }
		public SelectList LUniversiteler { get; set; }
		public SelectList LFakulteler { get; set; }
		public SelectList LBolumler { get; set; }
		public SelectList LMeslekler { get; set; }
	}
}
