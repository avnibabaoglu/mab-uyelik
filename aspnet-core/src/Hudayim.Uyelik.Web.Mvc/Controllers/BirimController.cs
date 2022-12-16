using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using Hudayim.Uyelik.Birims;
using Hudayim.Uyelik.Controllers;
using Hudayim.Uyelik.Web.Models.Birims;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Hudayim.Uyelik.Web.Controllers
{
	[AbpMvcAuthorize]
	public class BirimController : UyelikControllerBase
	{
		private readonly IBirimAppService _birimAppService;
		public BirimController(IBirimAppService birimAppService)
		{
			_birimAppService = birimAppService;
		}
		public ActionResult Index()
		{
			return View();
		}

		public async Task<ActionResult> EditModal(int birimId)
		{
			var birim = await _birimAppService.GetAsync(new EntityDto<int>(birimId));
			var model = new EditBirimModalViewModel
			{
				BirimDto = birim
			};

			return PartialView("_EditModal", model);
		}

	}

}
