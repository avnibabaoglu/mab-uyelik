using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using Hudayim.Uyelik.Controllers;
using Hudayim.Uyelik.Fakultes;
using Hudayim.Uyelik.Universites;
using Hudayim.Uyelik.Universites.Dto;
using Hudayim.Uyelik.Web.Models.Educations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hudayim.Uyelik.Web.Controllers
{
	[AbpMvcAuthorize]
	public class FakulteController : UyelikControllerBase
	{
		private readonly IUniversiteAppService _universiteAppService;
		private readonly IFakulteAppService _fakulteAppService;
		public FakulteController(IUniversiteAppService universiteAppService, IFakulteAppService fakulteAppService)
		{
			_universiteAppService = universiteAppService;
			_fakulteAppService = fakulteAppService;
		}

		public async Task<ActionResult> Index()
		{
			List<UniversiteDto> get_universiteler = new List<UniversiteDto>();
			get_universiteler = await _universiteAppService.GetAllAsyncDto(new PagedUniversiteResultRequestDto() { IsActive = false });

			var model = new EducationViewModel();
			model.LUniversiteler = new SelectList(get_universiteler, "Id", "Ad");

			return View("Index", model);
		}
		public async Task<ActionResult> EditModal(int fakulteId)
		{
			var fakulte = await _fakulteAppService.GetAsyncDto(new EntityDto<int>(fakulteId));

			List<UniversiteDto> get_universiteler = new List<UniversiteDto>();

			get_universiteler = await _universiteAppService.GetAllAsyncDto(new PagedUniversiteResultRequestDto() { IsActive = false });

			var model = new EditEducationModalViewModel
			{
				FakulteDto = fakulte,
				LUniversiteler = new SelectList(get_universiteler, "Id", "Ad"),
			};

			return PartialView("_EditModal", model);
		}
	}
}
