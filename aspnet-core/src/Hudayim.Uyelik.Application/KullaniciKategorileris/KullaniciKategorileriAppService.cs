using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Hudayim.Uyelik.Entities;
using Hudayim.Uyelik.KullaniciKategorileris.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hudayim.Uyelik.KullaniciKategorileris
{
	[AbpAuthorize]
	public class KullaniciKategorileriAppService : AsyncCrudAppService<KullaniciKategorileri, KullaniciKategorileriDto, int, PagedKullaniciKategorileriResultRequestDto, CreateKullaniciKategorileriDto, KullaniciKategorileriDto>, IKullaniciKategorileriAppService
	{
		private readonly IRepository<KullaniciKategorileri, int> _repository;
		public KullaniciKategorileriAppService(IRepository<KullaniciKategorileri, int> repository) : base(repository)
		{
			_repository = repository;
		}

		protected override IQueryable<KullaniciKategorileri> CreateFilteredQuery(PagedKullaniciKategorileriResultRequestDto input)
		{
			var data = Repository.GetAllIncluding()
						.Include(a => a.User)
						.Include(a => a.Kategori)
						.Where(a => a.IsDeleted == false)
						.WhereIf(input.UserId.HasValue, a => a.UserId == input.UserId)
						.WhereIf(input.KategoriId.HasValue, a => a.KategoriId == input.KategoriId)
						.AsQueryable();

			return data;
		}
		public async Task<List<KullaniciKategorileriDto>> GetAllAsyncDto(PagedKullaniciKategorileriResultRequestDto input)
		{
			var data = await _repository.GetAllListAsync(a => a.IsDeleted == false && a.UserId == input.UserId);
			var mapData = ObjectMapper.Map<List<KullaniciKategorileriDto>>(data);

			return mapData;
		}

		public async Task<KullaniciKategorileriDto> GetAsyncDto(EntityDto<int> id)
		{
			var data = await Repository.GetAllIncluding()
										.Include(a => a.User)
										.Include(a => a.Kategori)
										.Where(a => a.IsDeleted == false)
										.FirstOrDefaultAsync(a => a.Id == id.Id);

			var mapData = ObjectMapper.Map<KullaniciKategorileriDto>(data);

			return mapData;
		}

		public async Task<bool> CreateAsync(long? userId, string[] kategoriIds)
		{
			var returnValue = false;
			if (userId.HasValue && kategoriIds != null && kategoriIds.Count() > 0)
			{
				foreach (var kategoriId in kategoriIds)
				{
					var kategoriIdInt = Convert.ToInt32(kategoriId);
					var getItem = _repository.GetAllIncluding().FirstOrDefault(a => a.UserId == userId && a.KategoriId == kategoriIdInt);
					if (getItem == null)
					{
						CreateKullaniciKategorileriDto createInput = new CreateKullaniciKategorileriDto();

						createInput.UserId = userId;
						createInput.KategoriId = kategoriIdInt;

						var result = await base.CreateAsync(createInput);

						if (result.Id > 0)
							returnValue = true;
						else
							returnValue = false;
					}
				}
			}
			return returnValue;
		}
		public async Task<bool> UpdateAsync(long? userId, string[] kategoriIds)
		{
			var returnValue = false;
			if (userId.HasValue)
			{
				var delete_items_ids = _repository.GetAll().Where(a => !kategoriIds.Any(x => x == a.KategoriId.ToString()) && a.UserId == userId).Select(a => new EntityDto<int>() { Id = a.Id }).ToHashSet();
				if (delete_items_ids != null && delete_items_ids.Count() > 0)
				{
					foreach (var delete_item in delete_items_ids)
					{
						await base.DeleteAsync(delete_item);
					}
				}

				if (kategoriIds != null && kategoriIds.Count() > 0)
				{
					var items = _repository.GetAllIncluding().Where(a => a.UserId == userId);
					foreach (var kategoriId in kategoriIds)
					{
						var kategoriIdInt = Convert.ToInt32(kategoriId);
						var item = items.Where(a => a.KategoriId == kategoriIdInt).FirstOrDefault();
						if (item != null)
						{
							KullaniciKategorileriDto editInput = new KullaniciKategorileriDto();

							editInput.Id = item.Id;
							editInput.UserId = userId;
							editInput.KategoriId = kategoriIdInt;
							editInput.CreationTime = item.CreationTime;
							editInput.CreatorUserId = item.CreatorUserId;

							var result = await base.UpdateAsync(editInput);

							if (result.Id > 0)
								returnValue = true;
							else
								returnValue = false;
						}
						else
						{
							CreateKullaniciKategorileriDto createInput = new CreateKullaniciKategorileriDto();

							createInput.UserId = userId;
							createInput.KategoriId = kategoriIdInt;

							var result = await base.CreateAsync(createInput);

							if (result.Id > 0)
								returnValue = true;
							else
								returnValue = false;
						}
					}
				}
			}
			return returnValue;
		}

	}
}
