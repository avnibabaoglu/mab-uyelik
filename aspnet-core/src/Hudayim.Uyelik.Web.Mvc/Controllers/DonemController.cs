using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using Hudayim.Uyelik.Commons;
using Hudayim.Uyelik.Controllers;
using Hudayim.Uyelik.Donems;
using Hudayim.Uyelik.Web.Models.Donems;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace Hudayim.Uyelik.Web.Controllers
{
	[AbpMvcAuthorize]
	public class DonemController : UyelikControllerBase
	{
		private readonly ICommonAppService _commonService;
		private readonly IDonemAppService _donemAppService;
		public DonemController(ICommonAppService commonService, IDonemAppService donemAppService)
		{
			_commonService = commonService;
			_donemAppService = donemAppService;
		}

		public ActionResult Index()
		{
			var get_donem_turleri = _commonService.GetDonemTurleriList();

			var model = new DonemViewModel();
			model.LDonemTurleri = new SelectList(get_donem_turleri, "VALUE", "NAME");

			return View("Index", model);
		}

		public async Task<ActionResult> EditModal(int donemId)
		{
			var donemTurleri = _commonService.GetDonemTurleriList();
			var donem = await _donemAppService.GetAsync(new EntityDto<int>(donemId));

			var model = new EditDonemModalViewModel
			{
				LDonemTurleri = new SelectList(donemTurleri, "VALUE", "NAME"),
				DonemDto = donem
			};

			return PartialView("_EditModal", model);
		}

	}
}
