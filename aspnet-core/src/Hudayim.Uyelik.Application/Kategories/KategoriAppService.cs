using Abp.Application.Services;
using Abp.Authorization;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Hudayim.Uyelik.Entities;
using Hudayim.Uyelik.Kategories.Dto;
using System.Collections.Generic;
using System.Linq;

namespace Hudayim.Uyelik.Kategories
{
	[AbpAuthorize]
	public class KategoriAppService : AsyncCrudAppService<Kategori, KategoriDto, int, PagedKategoriResultRequestDto, CreateKategoriDto, KategoriDto>, IKategoriAppService
	{
		private readonly IRepository<Kategori, int> _repository;
		public KategoriAppService(IRepository<Kategori, int> repository) : base(repository)
		{
			_repository = repository;
		}

		protected override IQueryable<Kategori> CreateFilteredQuery(PagedKategoriResultRequestDto input)
		{
			var data = Repository.GetAll()
				.WhereIf(input.KategoriTuru.HasValue, x => x.KategoriTuru == input.KategoriTuru)
				.WhereIf(!input.Keyword.IsNullOrWhiteSpace(), x => x.Ad.Contains(input.Keyword))
				.WhereIf(input.IsActive.HasValue, x => x.AktifMi == input.IsActive)
				.AsQueryable();

			return data;
		}

		public List<KategoriDto> GetAllAsyncDto(PagedKategoriResultRequestDto input)
		{
			var data = CreateFilteredQuery(input);
			var orderData = ApplySorting(data, input);
			var mapData = ObjectMapper.Map<List<KategoriDto>>(orderData);

			return mapData;
		}

		protected override IQueryable<Kategori> ApplySorting(IQueryable<Kategori> query, PagedKategoriResultRequestDto input)
		{
			return query.OrderBy(r => r.SiraNo);
		}

	}
}
