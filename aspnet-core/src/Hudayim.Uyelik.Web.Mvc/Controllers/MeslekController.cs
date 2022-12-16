using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using Hudayim.Uyelik.Controllers;
using Hudayim.Uyelik.Mesleks;
using Hudayim.Uyelik.Web.Models.Mesleks;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Hudayim.Uyelik.Web.Controllers
{
	[AbpMvcAuthorize]
	public class MeslekController : UyelikControllerBase
	{
		private readonly IMeslekAppService _meslekAppService;
		public MeslekController(IMeslekAppService meslekAppService)
		{
			_meslekAppService = meslekAppService;
		}
		public ActionResult Index()
		{
			return View();
		}

		public async Task<ActionResult> EditModal(int meslekId)
		{
			var meslek = await _meslekAppService.GetAsync(new EntityDto<int>(meslekId));
			var model = new EditMeslekModalViewModel
			{
				MeslekDto = meslek
			};

			return PartialView("_EditModal", model);
		}

	}
}
