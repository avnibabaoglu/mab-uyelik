using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using Hudayim.Uyelik.Common;
using Hudayim.Uyelik.Controllers;
using Hudayim.Uyelik.Entities.Enums;
using Hudayim.Uyelik.Firmas;
using Hudayim.Uyelik.Firmas.Dto;
using Hudayim.Uyelik.Kampanyas;
using Hudayim.Uyelik.Kampanyas.Dto;
using Hudayim.Uyelik.Kategories;
using Hudayim.Uyelik.Kategories.Dto;
using Hudayim.Uyelik.Web.Models.Kampanyas;
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
	public class KampanyaController : UyelikControllerBase
	{
		IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json", false, false).Build();

		private readonly IWebHostEnvironment webHostEnvironment;
		private readonly IFirmaAppService _firmaAppService;
		private readonly IKampanyaAppService _kampanyaAppService;
		private readonly IKategoriAppService _kategoriAppService;
		public KampanyaController(IFirmaAppService firmaAppService, IKampanyaAppService kampanyaAppService, IKategoriAppService kategoriAppService, IWebHostEnvironment hostEnvironment)
		{
			webHostEnvironment = hostEnvironment;
			_firmaAppService = firmaAppService;
			_kampanyaAppService = kampanyaAppService;
			_kategoriAppService = kategoriAppService;
		}

		public async Task<ActionResult> Index()
		{
			var get_firmalar = await _firmaAppService.GetAllAsyncDto(new PagedFirmaResultRequestDto() { IsDeleted = false });
			var get_kampanyalar = await _kampanyaAppService.GetAllAsync(new PagedKampanyaResultRequestDto() { IsDeleted = false });
			var get_kategoriler = await _kategoriAppService.GetAllAsync(new PagedKategoriResultRequestDto() { KategoriTuru = KategoriTuruEnum.Firma, IsActive = true });


			var model = new KampanyaViewModel();
			model.Kampanyalar = get_kampanyalar.Items;
			model.LFirmaKategoriler = get_kategoriler.Items?.Select(a => new NameValueDto() { Value = a.Id.ToString(), Name = a.Ad }).ToList();
			model.LFirmalar = new SelectList(get_firmalar, "Id", "Ad");

			return View("Index", model);
		}
		public async Task<ActionResult> IndexAdmin()
		{
			var get_firmalar = await _firmaAppService.GetAllAsyncDto(new PagedFirmaResultRequestDto() { IsDeleted = false });

			var model = new KampanyaViewModel();
			model.LFirmalar = new SelectList(get_firmalar, "Id", "Ad");

			return View("IndexAdmin", model);
		}
		public async Task<ActionResult> EditModal(int kampanyaId)
		{
			var kampanya = await _kampanyaAppService.GetAsyncDto(new EntityDto<int>(kampanyaId));
			var get_firmalar = await _firmaAppService.GetAllAsyncDto(new PagedFirmaResultRequestDto() { IsDeleted = false });

			var model = new EditKampanyaModalViewModel();
			model.KampanyaDto = kampanya;
			model.LFirmalar = new SelectList(get_firmalar, "Id", "Ad");

			return PartialView("_EditModal", model);
		}

		[HttpPost]
		public async Task<JsonResult> FileUpload(string kampanyaAdi, IFormFile dosya)
		{
			var result = new Result<Tuple<string, string>>() { Success = false };
			try
			{
				string dosyaYolu = config["Files:KampanyaDosyaYolu"].ToString();
				string attachmentAllowExtension = config["Files:AllowedImageExtensions"].ToString();
				string maxFileSize = config["Files:MaxFileSize"].ToString();

				string dosyaAdi = $"{kampanyaAdi}-{DateTime.Now.ToShortDateString()}{Path.GetExtension(dosya.FileName)}";
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
					var data = await _kampanyaAppService.GetAsync(new EntityDto<int>(id.Value));
					if (data == null)
					{
						result.Success = false;
						result.Message = "Kampanya bulunamadı..";
						result.Data = false;

						return Json(result);
					}

					string dosyaYolu = data.ResimYolu;
					string dosyaAdi = data.ResimAdi;
					string dosyaTamYolu = $"{webHostEnvironment.WebRootPath}\\{dosyaYolu}\\{dosyaAdi}";

					data.ResimYolu = "";
					data.ResimAdi = "";

					var update_result = await _kampanyaAppService.UpdateAsync(data);
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
