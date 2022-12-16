using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using Hudayim.Uyelik.Commons;
using Hudayim.Uyelik.Controllers;
using Hudayim.Uyelik.Kategories;
using Hudayim.Uyelik.Web.Models.Kategories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace Hudayim.Uyelik.Web.Controllers
{
	[AbpMvcAuthorize]
	public class KategoriController : UyelikControllerBase
	{
		private readonly ICommonAppService _commonService;
		private readonly IKategoriAppService _kategoriAppService;
		public KategoriController(ICommonAppService commonService, IKategoriAppService kategoriAppService)
		{
			_commonService = commonService;
			_kategoriAppService = kategoriAppService;
		}
		public ActionResult Index()
		{
			var get_kategori_turleri = _commonService.GetKategoriTurleriList();

			var model = new KategoriViewModel();
			model.LKategorTurleri = new SelectList(get_kategori_turleri, "VALUE", "NAME");

			return View("Index", model);
		}
		public async Task<ActionResult> EditModal(int kategoriId)
		{
			var kategoriTurleri = _commonService.GetKategoriTurleriList();
			var kategori = await _kategoriAppService.GetAsync(new EntityDto<int>(kategoriId));
			var model = new EditKategoriModalViewModel
			{
				LKategorTurleri = new SelectList(kategoriTurleri, "VALUE", "NAME"),
				KategoriDto = kategori
			};

			return PartialView("_EditModal", model);
		}

	}
}
