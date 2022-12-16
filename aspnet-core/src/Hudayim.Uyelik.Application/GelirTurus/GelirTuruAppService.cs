using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Hudayim.Uyelik.Entities;
using Hudayim.Uyelik.GelirTurus.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hudayim.Uyelik.GelirTurus
{
	[AbpAuthorize]
	public class GelirTuruAppService : AsyncCrudAppService<GelirTuru, GelirTuruDto, int, PagedGelirTuruResultRequestDto, CreateGelirTuruDto, GelirTuruDto>, IGelirTuruAppService
	{
		private readonly IRepository<GelirTuru, int> _repository;
		public GelirTuruAppService(IRepository<GelirTuru, int> repository) : base(repository)
		{
			_repository = repository;
		}
		protected override IQueryable<GelirTuru> CreateFilteredQuery(PagedGelirTuruResultRequestDto input)
		{
			var data = Repository.GetAll()
				.WhereIf(!input.Keyword.IsNullOrWhiteSpace(), x => x.Ad.Contains(input.Keyword))
				.WhereIf(input.IsActive.HasValue, x => x.AktifMi == input.IsActive)
				.AsQueryable();

			return data;
		}
	
		public async Task<List<GelirTuruDto>> GetAllAsyncDto(PagedGelirTuruResultRequestDto input)
		{
			var data = await _repository.GetAllListAsync(a => a.AktifMi == input.IsActive);
			var mapData = ObjectMapper.Map<List<GelirTuruDto>>(data.OrderBy(a => a.SiraNo));

			return mapData;
		}

	}
}
