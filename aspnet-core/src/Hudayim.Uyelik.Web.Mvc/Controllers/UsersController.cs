using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using Hudayim.Uyelik.Authorization;
using Hudayim.Uyelik.Birims;
using Hudayim.Uyelik.Birims.Dto;
using Hudayim.Uyelik.Bolums;
using Hudayim.Uyelik.Bolums.Dto;
using Hudayim.Uyelik.Common;
using Hudayim.Uyelik.Controllers;
using Hudayim.Uyelik.Donems;
using Hudayim.Uyelik.Donems.Dto;
using Hudayim.Uyelik.Entities.Enums;
using Hudayim.Uyelik.Fakultes;
using Hudayim.Uyelik.Fakultes.Dto;
using Hudayim.Uyelik.Ilces;
using Hudayim.Uyelik.Ilces.Dto;
using Hudayim.Uyelik.Ils;
using Hudayim.Uyelik.Ils.Dto;
using Hudayim.Uyelik.Kategories;
using Hudayim.Uyelik.Kategories.Dto;
using Hudayim.Uyelik.KullaniciKategorileris;
using Hudayim.Uyelik.KullaniciKategorileris.Dto;
using Hudayim.Uyelik.Mahalles;
using Hudayim.Uyelik.Mahalles.Dto;
using Hudayim.Uyelik.Mesleks;
using Hudayim.Uyelik.Mesleks.Dto;
using Hudayim.Uyelik.Ulkes;
using Hudayim.Uyelik.Ulkes.Dto;
using Hudayim.Uyelik.Universites;
using Hudayim.Uyelik.Universites.Dto;
using Hudayim.Uyelik.Users;
using Hudayim.Uyelik.Web.Models.Users;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Hudayim.Uyelik.Web.Controllers
{
	[AbpMvcAuthorize(PermissionNames.Pages_Users, PermissionNames.Pages_Uye)]
	public class UsersController : UyelikControllerBase
	{
		IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json", false, false).Build();

		private readonly IWebHostEnvironment webHostEnvironment;
		private readonly IUserAppService _userAppService;
		private readonly IKategoriAppService _kategoriAppService;
		private readonly IDonemAppService _donemAppService;
		private readonly IBirimAppService _birimAppService;
		private readonly IUlkeAppService _ulkeAppService;
		private readonly IIlAppService _ilAppService;
		private readonly IIlceAppService _ilceAppService;
		private readonly IMahalleAppService _mahalleAppService;
		private readonly IUniversiteAppService _universiteAppService;
		private readonly IFakulteAppService _fakulteAppService;
		private readonly IBolumAppService _bolumAppService;
		private readonly IMeslekAppService _meslekAppService;
		private readonly IKullaniciKategorileriAppService _kullaniciKategorileriAppService;
		public UsersController(
					IUserAppService userAppService,
					IKategoriAppService kategoriAppService,
					IDonemAppService donemAppService,
					IBirimAppService birimAppService,
					IUlkeAppService ulkeAppService,
					IIlAppService ilAppService,
					IIlceAppService ilceAppService,
					IMahalleAppService mahalleAppService,
					IUniversiteAppService universiteAppService,
					IFakulteAppService fakulteAppService,
					IBolumAppService bolumAppService,
					IMeslekAppService meslekAppService,
					IWebHostEnvironment hostEnvironment,
					IKullaniciKategorileriAppService kullaniciKategorileriAppService)
		{
			webHostEnvironment = hostEnvironment;

			_userAppService = userAppService;
			_kategoriAppService = kategoriAppService;
			_donemAppService = donemAppService;
			_birimAppService = birimAppService;
			_ulkeAppService = ulkeAppService;
			_ilAppService = ilAppService;
			_ilceAppService = ilceAppService;
			_mahalleAppService = mahalleAppService;
			_universiteAppService = universiteAppService;
			_fakulteAppService = fakulteAppService;
			_bolumAppService = bolumAppService;
			_meslekAppService = meslekAppService;
			_kullaniciKategorileriAppService = kullaniciKategorileriAppService;
		}

		[HttpPost]
		public async Task<JsonResult> GetIller(int? ulkeId = null)
		{
			var get_result = ulkeId.HasValue == true ? await _ilAppService.GetAllAsyncDto(new PagedIlResultRequestDto { UlkeId = ulkeId, IsDeleted = false }) :
												await _ilAppService.GetAllAsyncDto(new PagedIlResultRequestDto { IsDeleted = false });

			var data = new SelectList(get_result, "Id", "Ad");
			var jsonResult = Json(data);
			return jsonResult;
		}

		[HttpPost]
		public async Task<JsonResult> GetIlceler(int? ilId = null)
		{
			var get_result = ilId.HasValue == true ? await _ilceAppService.GetAllAsyncDto(new PagedIlceResultRequestDto { IlId = ilId, IsDeleted = false }) :
											  await _ilceAppService.GetAllAsyncDto(new PagedIlceResultRequestDto { IsDeleted = false });


			var data = new SelectList(get_result, "Id", "Ad");
			var jsonResult = Json(data);
			return jsonResult;
		}

		[HttpPost]
		public async Task<JsonResult> GetMahalleler(int? ilceId = null)
		{
			var get_result = ilceId.HasValue == true ? await _mahalleAppService.GetAllAsyncDto(new PagedMahalleResultRequestDto { IlceId = ilceId, IsDeleted = false }) :
												await _mahalleAppService.GetAllAsyncDto(new PagedMahalleResultRequestDto { IsDeleted = false });

			var data = new SelectList(get_result, "Id", "Ad");
			var jsonResult = Json(data);
			return jsonResult;
		}

		[HttpPost]
		public async Task<JsonResult> GetUniversiteFakulteler(int? universiteId = null)
		{
			var get_result = universiteId.HasValue == true ?
								await _fakulteAppService.GetAllAsyncDto(new PagedFakulteResultRequestDto
								{
									UniversiteId = universiteId,
									IsDeleted = false
								})
								:
								await _fakulteAppService.GetAllAsyncDto(new PagedFakulteResultRequestDto
								{
									IsDeleted = false
								});

			var data = new SelectList(get_result, "Id", "Ad");
			var jsonResult = Json(data);
			return jsonResult;
		}

		[HttpPost]
		public async Task<JsonResult> GetUniversiteBolumler(int? fakulteId = null)
		{
			var get_result = fakulteId.HasValue == true ?
								await _bolumAppService.GetAllAsyncDto(new PagedBolumResultRequestDto
								{
									FakulteId = fakulteId,
									IsDeleted = false
								})
								:
								await _bolumAppService.GetAllAsyncDto(new PagedBolumResultRequestDto
								{
									IsDeleted = false
								});

			var data = new SelectList(get_result, "Id", "Ad");
			var jsonResult = Json(data);
			return jsonResult;
		}

		[HttpGet]
		public async Task<JsonResult> GetMeslekler(string searchTerm, int pageSize, int pageNum)
		{
			int total = 0;

			var get_result = await _meslekAppService.GetAllAsyncDto(new PagedMeslekResultRequestDto() { IsActive = true, Keyword = searchTerm.Trim() });
			if (get_result.Count < 1)
			{
				return Json(get_result);
			}

			total = get_result.Count();
			var dataList = get_result.ToList();

			var paging_result = PageListMeslekAsync(dataList, pageSize, pageNum);
			if (paging_result.TotalCount < 1)
			{
				return Json(paging_result);
			}

			var pagingData = paging_result.Items;
			var json_data = pagingData.Select(s => new
			{
				id = s.Id,
				text = s.Ad
			}).ToList();

			return Json(new { results = json_data, total = json_data.Count() });
		}

		public PagedResultDto<MeslekDto> PageListMeslekAsync(List<MeslekDto> list, int pageSize, int pageNum)
		{
			PagedResultDto<MeslekDto> result = new PagedResultDto<MeslekDto>();
			try
			{
				var query_result = list.OrderBy(s => s.Ad).Skip((pageNum - 1) * pageSize).Take(pageSize);

				if (query_result != null && query_result.Count() > 0)
				{
					result.Items = query_result.ToList();
					result.TotalCount = query_result.Count();
				}
				else
				{
					result.Items = new PagedResultDto<MeslekDto>().Items;
					result.TotalCount = 0;
				}

			}
			catch
			{
				result.Items = new PagedResultDto<MeslekDto>().Items;
				result.TotalCount = 0;
			}
			return result;
		}

		public ActionResult Index()
		{
			return View();
		}

		public async Task<ActionResult> Create()
		{
			var roles = (await _userAppService.GetRoles()).Items;
			var get_ulkeler = await _ulkeAppService.GetAllAsyncDto(new PagedUlkeResultRequestDto() { IsDeleted = false });
			var get_kategoriler = _kategoriAppService.GetAllAsyncDto(new PagedKategoriResultRequestDto() { IsActive = true, KategoriTuru = KategoriTuruEnum.Kullanici });
			var get_donemler = _donemAppService.GetAllAsyncDto(new PagedDonemResultRequestDto() { IsActive = true, DonemTuru = DonemTuruEnum.Mezun });
			var get_birimler = await _birimAppService.GetAllAsyncDto(new PagedBirimResultRequestDto() { IsActive = true });
			var get_universiteler = await _universiteAppService.GetAllAsyncDto(new PagedUniversiteResultRequestDto() { IsActive = true });

			var model = new UserViewModel();
			model.Roles = roles;
			model.LUlkeler = new SelectList(get_ulkeler, "Id", "Ad");
			model.LKategoriler = new SelectList(get_kategoriler, "Id", "Ad");
			model.LDonemler = new SelectList(get_donemler, "Id", "Ad");
			model.LBirimler = new SelectList(get_birimler, "Id", "Ad");
			model.LUniversiteler = new SelectList(get_universiteler, "Id", "Ad");

			return View(model);
		}

		public async Task<ActionResult> Edit(long id)
		{
			var user = await _userAppService.GetAsync(new EntityDto<long>(id));
			var roles = (await _userAppService.GetRoles()).Items;

			#region ÜLKE, İL, İLÇE, MAHALLE YÜKLEME YAPILIR.
			List<UlkeDto> get_ulkeler = new List<UlkeDto>();
			List<IlDto> get_iller = new List<IlDto>();
			List<IlceDto> get_ilceler = new List<IlceDto>();
			List<MahalleDto> get_mahalleler = new List<MahalleDto>();

			get_ulkeler = await _ulkeAppService.GetAllAsyncDto(new PagedUlkeResultRequestDto() { IsDeleted = false });

			if (user.UlkeId.HasValue == true)
			{
				var ulkeId = user.UlkeId;
				get_iller = await _ilAppService.GetAllAsyncDto(new PagedIlResultRequestDto() { UlkeId = ulkeId, IsDeleted = false });
			}
			else
			{
				get_iller = await _ilAppService.GetAllAsyncDto(new PagedIlResultRequestDto() { IsDeleted = false });
			}

			if (user.IlId.HasValue == true)
			{
				var ilId = user.IlId;
				get_ilceler = await _ilceAppService.GetAllAsyncDto(new PagedIlceResultRequestDto() { IsDeleted = false, IlId = ilId });
			}

			if (user.IlceId.HasValue == true)
			{
				var ilceId = user.IlceId;
				get_mahalleler = (await _mahalleAppService.GetAllAsyncDto(new PagedMahalleResultRequestDto() { IsDeleted = false, IlceId = ilceId }));
			}
			#endregion

			#region ÜNİVERSİTE, FAKÜLTE VE BÖLÜM YÜKLEME YAPILIR.
			List<UniversiteDto> get_universiteler = new List<UniversiteDto>();
			List<FakulteDto> get_fakulteler = new List<FakulteDto>();
			List<BolumDto> get_bolumler = new List<BolumDto>();

			get_universiteler = await _universiteAppService.GetAllAsyncDto(new PagedUniversiteResultRequestDto() { IsActive = true });

			if (user.UniversiteId.HasValue == true)
			{
				var universiteId = user.UniversiteId;
				get_fakulteler = await _fakulteAppService.GetAllAsyncDto(new PagedFakulteResultRequestDto() { UniversiteId = universiteId, IsDeleted = false });
			}

			if (user.FakulteId.HasValue == true)
			{
				var universiteId = user.UniversiteId;
				var fakulteId = user.FakulteId;

				get_bolumler = await _bolumAppService.GetAllAsyncDto(new PagedBolumResultRequestDto() { FakulteId = fakulteId, UniversiteId = universiteId, IsDeleted = false });
			}
			#endregion

			var get_kategoriler = _kategoriAppService.GetAllAsyncDto(new PagedKategoriResultRequestDto() { IsActive = true, KategoriTuru = KategoriTuruEnum.Kullanici });
			var get_user_kategoriler = await _kullaniciKategorileriAppService.GetAllAsyncDto(new PagedKullaniciKategorileriResultRequestDto() { UserId = id });
			var get_donemler = _donemAppService.GetAllAsyncDto(new PagedDonemResultRequestDto() { IsActive = true, DonemTuru = DonemTuruEnum.Mezun });
			var get_birimler = await _birimAppService.GetAllAsyncDto(new PagedBirimResultRequestDto() { IsActive = true });

			var model = new UserViewModel();
			model.User = user;
			model.Roles = roles;
			model.LUlkeler = new SelectList(get_ulkeler, "Id", "Ad");
			model.LIller = new SelectList(get_iller, "Id", "Ad");
			model.LIlceler = new SelectList(get_ilceler, "Id", "Ad");
			model.LMahalleler = new SelectList(get_mahalleler, "Id", "Ad");
			model.LKategoriler = new SelectList(get_kategoriler, "Id", "Ad");
			model.LKullaniciKategoriler = new SelectList(get_user_kategoriler, "KategoriId", "KategoriAdi");
			model.LDonemler = new SelectList(get_donemler, "Id", "Ad");
			model.LBirimler = new SelectList(get_birimler, "Id", "Ad");
			model.LUniversiteler = new SelectList(get_universiteler, "Id", "Ad");
			model.LFakulteler = new SelectList(get_fakulteler, "Id", "Ad");
			model.LBolumler = new SelectList(get_bolumler, "Id", "Ad");

			return View(model);
		}

		public async Task<ActionResult> EditAdmin(long id)
		{
			var user = await _userAppService.GetAsync(new EntityDto<long>(id));
			var roles = (await _userAppService.GetRoles()).Items;

			#region ÜLKE, İL, İLÇE, MAHALLE YÜKLEME YAPILIR.
			List<UlkeDto> get_ulkeler = new List<UlkeDto>();
			List<IlDto> get_iller = new List<IlDto>();
			List<IlceDto> get_ilceler = new List<IlceDto>();
			List<MahalleDto> get_mahalleler = new List<MahalleDto>();

			get_ulkeler = await _ulkeAppService.GetAllAsyncDto(new PagedUlkeResultRequestDto() { IsDeleted = false });

			if (user.UlkeId.HasValue == true)
			{
				var ulkeId = user.UlkeId;
				get_iller = await _ilAppService.GetAllAsyncDto(new PagedIlResultRequestDto() { UlkeId = ulkeId, IsDeleted = false });
			}
			else
			{
				get_iller = await _ilAppService.GetAllAsyncDto(new PagedIlResultRequestDto() { IsDeleted = false });
			}

			if (user.IlId.HasValue == true)
			{
				var ilId = user.IlId;
				get_ilceler = await _ilceAppService.GetAllAsyncDto(new PagedIlceResultRequestDto() { IsDeleted = false, IlId = ilId });
			}

			if (user.IlceId.HasValue == true)
			{
				var ilceId = user.IlceId;
				get_mahalleler = (await _mahalleAppService.GetAllAsyncDto(new PagedMahalleResultRequestDto() { IsDeleted = false, IlceId = ilceId }));
			}
			#endregion

			#region ÜNİVERSİTE, FAKÜLTE VE BÖLÜM YÜKLEME YAPILIR.
			List<UniversiteDto> get_universiteler = new List<UniversiteDto>();
			List<FakulteDto> get_fakulteler = new List<FakulteDto>();
			List<BolumDto> get_bolumler = new List<BolumDto>();

			get_universiteler = await _universiteAppService.GetAllAsyncDto(new PagedUniversiteResultRequestDto() { IsActive = true });

			if (user.UniversiteId.HasValue == true)
			{
				var universiteId = user.UniversiteId;
				get_fakulteler = await _fakulteAppService.GetAllAsyncDto(new PagedFakulteResultRequestDto() { UniversiteId = universiteId, IsDeleted = false });
			}

			if (user.FakulteId.HasValue == true)
			{
				var universiteId = user.UniversiteId;
				var fakulteId = user.FakulteId;

				get_bolumler = await _bolumAppService.GetAllAsyncDto(new PagedBolumResultRequestDto() { FakulteId = fakulteId, UniversiteId = universiteId, IsDeleted = false });
			}
			#endregion

			var get_kategoriler = _kategoriAppService.GetAllAsyncDto(new PagedKategoriResultRequestDto() { IsActive = true, KategoriTuru = KategoriTuruEnum.Kullanici });
			var get_user_kategoriler = await _kullaniciKategorileriAppService.GetAllAsyncDto(new PagedKullaniciKategorileriResultRequestDto() { UserId = id });
			var get_donemler = _donemAppService.GetAllAsyncDto(new PagedDonemResultRequestDto() { IsActive = true, DonemTuru = DonemTuruEnum.Mezun });
			var get_birimler = await _birimAppService.GetAllAsyncDto(new PagedBirimResultRequestDto() { IsActive = true });

			var model = new UserViewModel();
			model.User = user;
			model.Roles = roles;
			model.LUlkeler = new SelectList(get_ulkeler, "Id", "Ad");
			model.LIller = new SelectList(get_iller, "Id", "Ad");
			model.LIlceler = new SelectList(get_ilceler, "Id", "Ad");
			model.LMahalleler = new SelectList(get_mahalleler, "Id", "Ad");
			model.LKategoriler = new SelectList(get_kategoriler, "Id", "Ad");
			model.LKullaniciKategoriler = new SelectList(get_user_kategoriler, "KategoriId", "KategoriAdi");
			model.LDonemler = new SelectList(get_donemler, "Id", "Ad");
			model.LBirimler = new SelectList(get_birimler, "Id", "Ad");
			model.LUniversiteler = new SelectList(get_universiteler, "Id", "Ad");
			model.LFakulteler = new SelectList(get_fakulteler, "Id", "Ad");
			model.LBolumler = new SelectList(get_bolumler, "Id", "Ad");

			return View(model);
		}

		public ActionResult ChangePassword()
		{
			return View();
		}

		[HttpPost]
		public async Task<JsonResult> FileUpload(string userName, IFormFile dosya)
		{
			var result = new Result<Tuple<string, string>>() { Success = false };

			try
			{
				string dosyaYolu = config["Files:KullaniciDosyaYolu"].ToString();
				string attachmentAllowExtension = config["Files:AllowedImageExtensions"].ToString();
				string maxFileSize = config["Files:MaxFileSize"].ToString();

				string dosyaAdi = $"{userName}-{DateTime.Now.ToShortDateString()}{Path.GetExtension(dosya.FileName)}";
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
		public async Task<JsonResult> FileDelete(long? id)
		{
			var result = new Result<bool>() { Success = false, Data = false };
			try
			{
				if (id.HasValue)
				{
					var user = await _userAppService.GetAsync(new EntityDto<long>(id.Value));
					if (user == null)
					{
						result.Success = false;
						result.Message = "Kullanıcı bulunamadı..";
						result.Data = false;

						return Json(result);
					}

					string dosyaYolu = user.ProfilFotografYolu;
					string dosyaAdi = user.ProfilFotografAdi;
					string dosyaTamYolu = $"{webHostEnvironment.WebRootPath}\\{dosyaYolu}\\{dosyaAdi}";

					user.ProfilFotografYolu = "";
					user.ProfilFotografAdi = "";

					var update_result = await _userAppService.UpdateAsync(user);

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
