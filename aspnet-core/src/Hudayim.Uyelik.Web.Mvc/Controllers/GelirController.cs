using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using Hudayim.Uyelik.Controllers;
using Hudayim.Uyelik.Donems;
using Hudayim.Uyelik.Donems.Dto;
using Hudayim.Uyelik.Entities.Enums;
using Hudayim.Uyelik.Gelirs;
using Hudayim.Uyelik.GelirTurus;
using Hudayim.Uyelik.GelirTurus.Dto;
using Hudayim.Uyelik.Users;
using Hudayim.Uyelik.Users.Dto;
using Hudayim.Uyelik.Web.Models.Gelirs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hudayim.Uyelik.Web.Controllers
{
	[AbpMvcAuthorize]
	public class GelirController : UyelikControllerBase
	{
		private readonly IGelirAppService _gelirAppService;
		private readonly IGelirTuruAppService _gelirTuruAppService;
		private readonly IDonemAppService _donemAppService;
		private readonly IUserAppService _userAppService;


		public GelirController(IGelirAppService gelirAppService,
								IGelirTuruAppService gelirTuruAppService,
								IDonemAppService donemAppService,
								IUserAppService userAppService)
		{
			_gelirAppService = gelirAppService;
			_gelirTuruAppService = gelirTuruAppService;
			_donemAppService = donemAppService;
			_userAppService = userAppService;
		}

		public ActionResult Index()
		{
			return View("Index");
		}

		[HttpGet]
		public async Task<JsonResult> GetKullanicilar(string searchTerm, int pageSize, int pageNum)
		{
			int total = 0;

			var get_result = await _userAppService.GetAllAsync(new PagedUserResultRequestDto() { IsActive = true, Keyword = searchTerm.Trim() });
			if (get_result.TotalCount < 1)
			{
				return Json(get_result);
			}

			total = get_result.Items.Count();
			var dataList = get_result.Items.ToList();

			var paging_result = PageListUserAsync(dataList, pageSize, pageNum);
			if (paging_result.TotalCount < 1)
			{
				return Json(paging_result);
			}

			var pagingData = paging_result.Items;
			var json_data = pagingData.Select(s => new
			{
				id = s.Id,
				text = s.FullName
			}).ToList();

			return Json(new { results = json_data, total = json_data.Count() });
		}

		public PagedResultDto<UserDto> PageListUserAsync(List<UserDto> userList, int pageSize, int pageNum)
		{
			PagedResultDto<UserDto> result = new PagedResultDto<UserDto>();
			try
			{
				var query_result = userList.OrderBy(s => s.Name).Skip((pageNum - 1) * pageSize).Take(pageSize);

				if (query_result != null && query_result.Count() > 0)
				{
					result.Items = query_result.ToList();
					result.TotalCount = query_result.Count();
				}
				else
				{
					result.Items = new PagedResultDto<UserDto>().Items;
					result.TotalCount = 0;
				}

			}
			catch
			{
				result.Items = new PagedResultDto<UserDto>().Items;
				result.TotalCount = 0;
			}
			return result;
		}

		public async Task<ActionResult> Create(long? userId)
		{
			var get_donemler = _donemAppService.GetAllAsyncDto(new PagedDonemResultRequestDto() { IsActive = true, DonemTuru = DonemTuruEnum.Gelir });
			var get_gelir_turleri = await _gelirTuruAppService.GetAllAsyncDto(new PagedGelirTuruResultRequestDto() { IsActive = true });

			var vm = new GelirViewModel();
			vm.UserDto = userId.HasValue ? await _userAppService.GetAsync(new EntityDto<long>(userId.Value)) : new UserDto();
			vm.LDonemler = new SelectList(get_donemler, "Id", "Ad");
			vm.LGelirTurleri = new SelectList(get_gelir_turleri, "Id", "Ad");

			return View(vm);
		}

		public async Task<ActionResult> Edit(int id)
		{
			var gelir_result = await _gelirAppService.GetAsyncDto(new EntityDto<int>(id));
			var get_donemler = _donemAppService.GetAllAsyncDto(new PagedDonemResultRequestDto() { IsActive = true });
			var get_gelir_turleri = await _gelirTuruAppService.GetAllAsyncDto(new PagedGelirTuruResultRequestDto() { IsActive = true });

			var vm = new GelirViewModel();

			vm.GelirDto = gelir_result;
			vm.LDonemler = new SelectList(get_donemler, "Id", "Ad");
			vm.LGelirTurleri = new SelectList(get_gelir_turleri, "Id", "Ad");

			return View(vm);
		}

	}
}
