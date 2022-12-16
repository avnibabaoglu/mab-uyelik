using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using Hudayim.Uyelik.Controllers;
using Hudayim.Uyelik.Ilces;
using Hudayim.Uyelik.Ils;
using Hudayim.Uyelik.Ils.Dto;
using Hudayim.Uyelik.Ulkes;
using Hudayim.Uyelik.Ulkes.Dto;
using Hudayim.Uyelik.Web.Models.Addresses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hudayim.Uyelik.Web.Controllers
{
	[AbpMvcAuthorize]
	public class IlceController : UyelikControllerBase
	{
		private readonly IUlkeAppService _ulkeAppService;
		private readonly IIlAppService _ilAppService;
		private readonly IIlceAppService _ilceAppService;
		public IlceController(IUlkeAppService ulkeAppService,
								IIlAppService ilAppService,
								IIlceAppService ilceAppService)
		{
			_ulkeAppService = ulkeAppService;
			_ilAppService = ilAppService;
			_ilceAppService = ilceAppService;
		}

		[HttpPost]
		public async Task<JsonResult> GetIller(int? ulkeId = null)
		{
			var get_result = ulkeId.HasValue == true ?
								await _ilAppService.GetAllAsyncDto(new PagedIlResultRequestDto
								{
									UlkeId = ulkeId,
									IsDeleted = false
								}) :
								await _ilAppService.GetAllAsyncDto(new PagedIlResultRequestDto
								{
									IsDeleted = false
								});

			var data = new SelectList(get_result, "Id", "Ad");
			var jsonResult = Json(data);
			return jsonResult;
		}

		public async Task<ActionResult> Index()
		{
			List<UlkeDto> get_ulkeler = new List<UlkeDto>();
			get_ulkeler = await _ulkeAppService.GetAllAsyncDto(new PagedUlkeResultRequestDto() { IsDeleted = false });

			var model = new AddressViewModel();
			model.LUlkeler = new SelectList(get_ulkeler, "Id", "Ad");

			return View("Index", model);
		}
		public async Task<ActionResult> EditModal(int ilceId)
		{
			var ilce = await _ilceAppService.GetAsyncDto(new EntityDto<int>(ilceId));

			#region ÜLKE, İL, İLÇE, MAHALLE YÜKLEME YAPILIR.
			List<UlkeDto> get_ulkeler = new List<UlkeDto>();
			List<IlDto> get_iller = new List<IlDto>();

			get_ulkeler = await _ulkeAppService.GetAllAsyncDto(new PagedUlkeResultRequestDto() { IsDeleted = false });

			if (ilce.UlkeId.HasValue == true)
			{
				var ulkeId = ilce.UlkeId;
				get_iller = await _ilAppService.GetAllAsyncDto(new PagedIlResultRequestDto() { UlkeId = ulkeId, IsDeleted = false });
			}
			else
			{
				get_iller = await _ilAppService.GetAllAsyncDto(new PagedIlResultRequestDto() { IsDeleted = false });
			}

			#endregion

			var model = new EditAddressModalViewModel
			{
				IlceDto = ilce,
				LUlkeler = new SelectList(get_ulkeler, "Id", "Ad"),
				LIller = new SelectList(get_iller, "Id", "Ad"),
			};

			return PartialView("_EditModal", model);
		}
	}
}
