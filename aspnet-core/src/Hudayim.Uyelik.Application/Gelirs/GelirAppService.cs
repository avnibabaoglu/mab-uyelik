using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Hudayim.Uyelik.Entities;
using Hudayim.Uyelik.Gelirs.Dto;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hudayim.Uyelik.Gelirs
{
	[AbpAuthorize]
	public class GelirAppService : AsyncCrudAppService<Gelir, GelirDto, int, PagedGelirResultRequestDto, CreateGelirDto, GelirDto>, IGelirAppService
	{
		private readonly IRepository<Gelir, int> _repository;
		public GelirAppService(IRepository<Gelir, int> repository) : base(repository)
		{
			_repository = repository;
		}
		protected override IQueryable<Gelir> CreateFilteredQuery(PagedGelirResultRequestDto input)
		{
			var data = Repository.GetAllIncluding()
						.Include(a => a.Donem)
						.Include(a => a.GelirTuru)
						.Include(a => a.User)
						.WhereIf(!input.Keyword.IsNullOrWhiteSpace(), x => x.Ad.Contains(input.Keyword))
						.WhereIf(input.IsActive.HasValue, x => x.AktifMi == input.IsActive)
						.AsQueryable();

			return data;
		}
		public async Task<List<GelirDto>> GetAllAsyncDto(PagedGelirResultRequestDto input)
		{
			var data = await _repository.GetAllListAsync(a => a.AktifMi == input.IsActive);
			var mapData = ObjectMapper.Map<List<GelirDto>>(data.OrderBy(a => a.SiraNo));

			return mapData;
		}

		public async Task<GelirDto> GetAsyncDto(EntityDto<int> id)
		{
			var data = await Repository.GetAllIncluding()
										.Include(a => a.Donem)
										.Include(a => a.GelirTuru)
										.Include(a => a.User)
										.FirstOrDefaultAsync(a => a.Id == id.Id);

			var mapData = ObjectMapper.Map<GelirDto>(data);

			return mapData;
		}
	}
}
