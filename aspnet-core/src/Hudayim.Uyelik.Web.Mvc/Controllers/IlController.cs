using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using Hudayim.Uyelik.Controllers;
using Hudayim.Uyelik.Ils;
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
	public class IlController : UyelikControllerBase
	{
		private readonly IUlkeAppService _ulkeAppService;
		private readonly IIlAppService _ilAppService;
		public IlController(IUlkeAppService ulkeAppService, IIlAppService ilAppService)
		{
			_ulkeAppService = ulkeAppService;
			_ilAppService = ilAppService;
		}

		public async Task<ActionResult> Index()
		{
			List<UlkeDto> get_ulkeler = new List<UlkeDto>();
			get_ulkeler = await _ulkeAppService.GetAllAsyncDto(new PagedUlkeResultRequestDto() { IsDeleted = false });

			var model = new AddressViewModel();
			model.LUlkeler = new SelectList(get_ulkeler, "Id", "Ad");

			return View("Index", model);
		}
		public async Task<ActionResult> EditModal(int ilId)
		{
			var il = await _ilAppService.GetAsyncDto(new EntityDto<int>(ilId));

			List<UlkeDto> get_ulkeler = new List<UlkeDto>();

			get_ulkeler = await _ulkeAppService.GetAllAsyncDto(new PagedUlkeResultRequestDto() { IsDeleted = false });

			var model = new EditAddressModalViewModel
			{
				IlDto = il,
				LUlkeler = new SelectList(get_ulkeler, "Id", "Ad"),
			};

			return PartialView("_EditModal", model);
		}
	}
}
