using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using Hudayim.Uyelik.Common;
using Hudayim.Uyelik.Controllers;
using Hudayim.Uyelik.Entities.Enums;
using Hudayim.Uyelik.Firmas;
using Hudayim.Uyelik.Ils;
using Hudayim.Uyelik.Ils.Dto;
using Hudayim.Uyelik.Kategories;
using Hudayim.Uyelik.Kategories.Dto;
using Hudayim.Uyelik.Web.Models.Firmas;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Hudayim.Uyelik.Web.Controllers
{
	[AbpMvcAuthorize]
	public class FirmaController : UyelikControllerBase
	{
		IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json", false, false).Build();

		private readonly IWebHostEnvironment webHostEnvironment;
		private readonly IFirmaAppService _firmaAppService;
		private readonly IIlAppService _ilAppService;
		private readonly IKategoriAppService _kategoriAppService;
		public FirmaController(IFirmaAppService firmaAppService, IIlAppService ilAppService, IKategoriAppService kategoriAppService, IWebHostEnvironment hostEnvironment)
		{
			webHostEnvironment = hostEnvironment;
			_firmaAppService = firmaAppService;
			_ilAppService = ilAppService;
			_kategoriAppService = kategoriAppService;
		}
		public async Task<ActionResult> Index()
		{
			var get_iller = await _ilAppService.GetAllAsyncDto(new PagedIlResultRequestDto() { IsDeleted = false });
			var get_kategoriler = _kategoriAppService.GetAllAsyncDto(new PagedKategoriResultRequestDto() { IsActive = true, KategoriTuru = KategoriTuruEnum.Firma });

			var model = new FirmaViewModel();
			model.LIller = new SelectList(get_iller, "Id", "Ad");
			model.LKategoriler = new SelectList(get_kategoriler, "Id", "Ad");

			return View("Index", model);
		}
		public async Task<ActionResult> EditModal(int firmaId)
		{
			var firma = await _firmaAppService.GetAsyncDto(new EntityDto<int>(firmaId));
			var get_iller = await _ilAppService.GetAllAsyncDto(new PagedIlResultRequestDto() { IsDeleted = false });
			var get_kategoriler = _kategoriAppService.GetAllAsyncDto(new PagedKategoriResultRequestDto() { IsActive = true, KategoriTuru = KategoriTuruEnum.Firma });

			var model = new EditFirmaModalViewModel();
			model.FirmaDto = firma;
			model.LIller = new SelectList(get_iller, "Id", "Ad");
			model.LKategoriler = new SelectList(get_kategoriler, "Id", "Ad");

			return PartialView("_EditModal", model);
		}

		[HttpPost]
		public async Task<JsonResult> FileUpload(string firmaAdi, IFormFile dosya)
		{
			var result = new Result<Tuple<string, string>>() { Success = false };
			try
			{
				string dosyaYolu = config["Files:FirmaDosyaYolu"].ToString();
				string attachmentAllowExtension = config["Files:AllowedImageExtensions"].ToString();
				string maxFileSize = config["Files:MaxFileSize"].ToString();

				string dosyaAdi = $"{firmaAdi}-{DateTime.Now.ToShortDateString()}{Path.GetExtension(dosya.FileName)}";
				string dosyaTamYolu = Path.Combine(webHostEnvironment.WebRootPath, dosyaYolu, dosyaAdi);

				var IzinVerilenDosyaTurleri = attachmentAllowExtension.Split(',').ToList();

				var maxFileSizeInt = Convert.ToInt32(maxFileSize);
				if (dosya != null && dosya.Length > maxFileSizeInt)
				{
					result.Success = false;
					result.Message = $"{dosya.FileName} adlı dosya için boyut uyarısı ! <br/> Ek maksimum 5 MB olabilir"; ;
					result.Data = null;

					return Json(result);
				}

				if (!IzinVerilenDosyaTurleri.Any(x => x == Path.GetExtension(dosya.FileName)))
				{
					result.Success = false;
					result.Message = dosya.FileName + " adlı dosya için uzantı uyarısı ! <br/> Ek için desteklenen dosya türleri: " + string.Join(",", IzinVerilenDosyaTurleri) + " türleridir!";
					result.Data = null;

					return Json(result);
				}

				using (var fileStream = new FileStream(dosyaTamYolu, FileMode.Create, FileAccess.Write))
				{
					await dosya.CopyToAsync(fileStream);
				}

				FileInfo file = new FileInfo(dosyaTamYolu);
				if (file.Exists)
				{
					result.Success = true;
					result.Data = new Tuple<string, string>(dosyaYolu, dosyaAdi);
				}
				else
				{
					result.Success = false;
					result.Message = "Ek yükleme işlemi sırasında bir hata meydana geldi. Ek  yükleme işlemini tekrar yapınız.";
					result.Data = null;
				}
				return Json(result);
			}
			catch
			{
				result.Success = false;
				result.Message = "Ek yükleme işlemi sırasında bir hata meydana geldi. Ek  yükleme işlemini tekrar yapınız.";
				result.Data = null;

				return Json(result);
			}
		}

		[HttpPost]
		public async Task<JsonResult> FileDelete(int? id)
		{
			var result = new Result<bool>() { Success = false, Data = false };
			try
			{
				if (id.HasValue)
				{
					var firma = await _firmaAppService.GetAsync(new EntityDto<int>(id.Value));
					if (firma == null)
					{
						result.Success = false;
						result.Message = "Firma bulunamadı..";
						result.Data = false;

						return Json(result);
					}

					string dosyaYolu = firma.ResimYolu;
					string dosyaAdi = firma.ResimAdi;
					string dosyaTamYolu = $"{webHostEnvironment.WebRootPath}\\{dosyaYolu}\\{dosyaAdi}";

					firma.ResimYolu = "";
					firma.ResimAdi = "";

					var update_result = await _firmaAppService.UpdateAsync(firma);

					if (update_result.Id > 0)
					{
						if (System.IO.File.Exists(dosyaTamYolu))
							System.IO.File.Delete(dosyaTamYolu);

						result.Success = true;
						result.Data = true;
					}
					else
					{
						result.Success = false;
						result.Message = "Ek silme işlemi sırasında bir hata meydana geldi. Tekrar deneyiniz..";
						result.Data = false;

						return Json(result);
					}
					return Json(result);
				}
				else
				{
					result.Success = false;
					result.Message = "Hata oluştu. Tekrar deneyiniz..";
					result.Data = false;

					return Json(result);
				}
			}
			catch
			{
				result.Success = false;
				result.Message = "Ek silme işlemi sırasında bir hata meydana geldi. Tekrar deneyiniz..";
				result.Data = false;

				return Json(result);
			}
		}

	}
}
