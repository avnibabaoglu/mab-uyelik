using Hudayim.Uyelik.Mesleks.Dto;
using System.Collections.Generic;

namespace Hudayim.Uyelik.Web.Models.Mesleks
{
	public class MeslekViewModel
	{
		public IReadOnlyList<MeslekDto> Meslekler { get; set; }
	}
}
