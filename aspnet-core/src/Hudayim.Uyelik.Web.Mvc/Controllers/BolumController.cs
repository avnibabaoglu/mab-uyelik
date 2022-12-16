using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using Hudayim.Uyelik.Bolums;
using Hudayim.Uyelik.Controllers;
using Hudayim.Uyelik.Fakultes;
using Hudayim.Uyelik.Fakultes.Dto;
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
	public class BolumController : UyelikControllerBase
	{
		private readonly IUniversiteAppService _universiteAppService;
		private readonly IFakulteAppService _fakulteAppService;
		private readonly IBolumAppService _bolumAppService;
		public BolumController(IUniversiteAppService universiteAppService,
								IFakulteAppService fakulteAppService,
								IBolumAppService bolumAppService)
		{
			_universiteAppService = universiteAppService;
			_fakulteAppService = fakulteAppService;
			_bolumAppService = bolumAppService;
		}

		[HttpPost]
		public async Task<JsonResult> GetFakulteler(int? universiteId = null)
		{
			var get_result = universiteId.HasValue == true ?
								await _fakulteAppService.GetAllAsyncDto(new PagedFakulteResultRequestDto
								{
									IsDeleted = false,
									UniversiteId = universiteId

								}) :
								await _fakulteAppService.GetAllAsyncDto(new PagedFakulteResultRequestDto
								{
									IsDeleted = false
								});

			var data = new SelectList(get_result, "Id", "Ad");
			var jsonResult = Json(data);
			return jsonResult;
		}

		public async Task<ActionResult> Index()
		{
			List<UniversiteDto> get_universiteler = new List<UniversiteDto>();
			get_universiteler = await _universiteAppService.GetAllAsyncDto(new PagedUniversiteResultRequestDto() { IsActive = false });

			var model = new EducationViewModel();
			model.LUniversiteler = new SelectList(get_universiteler, "Id", "Ad");

			return View("Index", model);
		}
		public async Task<ActionResult> EditModal(int bolumId)
		{
			var bolum = await _bolumAppService.GetAsyncDto(new EntityDto<int>(bolumId));

			List<UniversiteDto> get_universiteler = new List<UniversiteDto>();
			List<FakulteDto> get_fakulteler = new List<FakulteDto>();

			get_universiteler = await _universiteAppService.GetAllAsyncDto(new PagedUniversiteResultRequestDto() { IsActive = false });

			if (bolum.UniversiteId.HasValue == true)
			{
				var universiteId = bolum.UniversiteId;
				get_fakulteler = await _fakulteAppService.GetAllAsyncDto(new PagedFakulteResultRequestDto() { UniversiteId = universiteId, IsDeleted = false });
			}
			else
			{
				get_fakulteler = await _fakulteAppService.GetAllAsyncDto(new PagedFakulteResultRequestDto() { IsDeleted = false });
			}

			var model = new EditEducationModalViewModel
			{
				BolumDto = bolum,
				LUniversiteler = new SelectList(get_universiteler, "Id", "Ad"),
				LFakulteler = new SelectList(get_fakulteler, "Id", "Ad"),
			};

			return PartialView("_EditModal", model);
		}
	}
}
