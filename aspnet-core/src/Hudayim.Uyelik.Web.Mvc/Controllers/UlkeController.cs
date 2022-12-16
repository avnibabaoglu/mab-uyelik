using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using Hudayim.Uyelik.Controllers;
using Hudayim.Uyelik.Ulkes;
using Hudayim.Uyelik.Web.Models.Addresses;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Hudayim.Uyelik.Web.Controllers
{
	[AbpMvcAuthorize]
	public class UlkeController : UyelikControllerBase
	{
		private readonly IUlkeAppService _ulkeAppService;
		public UlkeController(IUlkeAppService ulkeAppService)
		{
			_ulkeAppService = ulkeAppService;
		}

		public ActionResult Index()
		{
			return View();
		}
		public async Task<ActionResult> EditModal(int ulkeId)
		{
			var ulke = await _ulkeAppService.GetAsync(new EntityDto<int>(ulkeId));
			var model = new EditAddressModalViewModel
			{
				UlkeDto = ulke
			};

			return PartialView("_EditModal", model);
		}
	}
}
