using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using Hudayim.Uyelik.Controllers;
using Hudayim.Uyelik.Universites;
using Hudayim.Uyelik.Web.Models.Educations;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Hudayim.Uyelik.Web.Controllers
{
	[AbpMvcAuthorize]
	public class UniversiteController : UyelikControllerBase
	{
		private readonly IUniversiteAppService _universiteAppService;
		public UniversiteController(IUniversiteAppService universiteAppService)
		{
			_universiteAppService = universiteAppService;
		}

		public ActionResult Index()
		{
			return View();
		}
		public async Task<ActionResult> EditModal(int universiteId)
		{
			var universite = await _universiteAppService.GetAsync(new EntityDto<int>(universiteId));
			var model = new EditEducationModalViewModel
			{
				UniversiteDto = universite
			};

			return PartialView("_EditModal", model);
		}
	}
}
