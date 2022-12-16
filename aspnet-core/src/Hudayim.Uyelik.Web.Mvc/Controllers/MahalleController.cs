using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using Hudayim.Uyelik.Controllers;
using Hudayim.Uyelik.Ilces;
using Hudayim.Uyelik.Ilces.Dto;
using Hudayim.Uyelik.Ils;
using Hudayim.Uyelik.Ils.Dto;
using Hudayim.Uyelik.Mahalles;
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
	public class MahalleController : UyelikControllerBase
	{
		private readonly IUlkeAppService _ulkeAppService;
		private readonly IIlAppService _ilAppService;
		private readonly IIlceAppService _ilceAppService;
		private readonly IMahalleAppService _mahalleAppService;
		public MahalleController(IUlkeAppService ulkeAppService,
								IIlAppService ilAppService,
								IIlceAppService ilceAppService,
								IMahalleAppService mahalleAppService)
		{
			_ulkeAppService = ulkeAppService;
			_ilAppService = ilAppService;
			_ilceAppService = ilceAppService;
			_mahalleAppService = mahalleAppService;
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

		[HttpPost]
		public async Task<JsonResult> GetIlceler(int? ilId = null)
		{
			var get_result = ilId.HasValue == true ?
								await _ilceAppService.GetAllAsyncDto(new PagedIlceResultRequestDto
								{
									IlId = ilId,
									IsDeleted = false
								})
								:
								await _ilceAppService.GetAllAsyncDto(new PagedIlceResultRequestDto
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

		public async Task<ActionResult> EditModal(int mahalleId)
		{
			var mahalle = await _mahalleAppService.GetAsyncDto(new EntityDto<int>(mahalleId));

			#region ÜLKE, İL, İLÇE, MAHALLE YÜKLEME YAPILIR.
			List<UlkeDto> get_ulkeler = new List<UlkeDto>();
			List<IlDto> get_iller = new List<IlDto>();
			List<IlceDto> get_ilceler = new List<IlceDto>();

			get_ulkeler = await _ulkeAppService.GetAllAsyncDto(new PagedUlkeResultRequestDto() { IsDeleted = false });

			if (mahalle.UlkeId.HasValue == true)
			{
				var ulkeId = mahalle.UlkeId;
				get_iller = await _ilAppService.GetAllAsyncDto(new PagedIlResultRequestDto() { UlkeId = ulkeId, IsDeleted = false });
			}
			else
			{
				get_iller = await _ilAppService.GetAllAsyncDto(new PagedIlResultRequestDto() { IsDeleted = false });
			}

			if (mahalle.IlId.HasValue == true)
			{
				var ilId = mahalle.IlId;
				get_ilceler = await _ilceAppService.GetAllAsyncDto(new PagedIlceResultRequestDto() { IsDeleted = false, IlId = ilId });
			}

			#endregion

			var model = new EditAddressModalViewModel
			{
				MahalleDto = mahalle,
				LUlkeler = new SelectList(get_ulkeler, "Id", "Ad"),
				LIller = new SelectList(get_iller, "Id", "Ad"),
				LIlceler = new SelectList(get_ilceler, "Id", "Ad"),
			};

			return PartialView("_EditModal", model);
		}
	}
}
