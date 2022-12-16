using Abp.Application.Services;
using Abp.Authorization;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Hudayim.Uyelik.Birims.Dto;
using Hudayim.Uyelik.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hudayim.Uyelik.Birims
{
	[AbpAuthorize]
	public class BirimAppService : AsyncCrudAppService<Birim, BirimDto, int, PagedBirimResultRequestDto, CreateBirimDto, BirimDto>, IBirimAppService
	{
		private readonly IRepository<Birim, int> _repository;
		public BirimAppService(IRepository<Birim, int> repository) : base(repository)
		{
			_repository = repository;
		}
		protected override IQueryable<Birim> CreateFilteredQuery(PagedBirimResultRequestDto input)
		{
			var data = Repository.GetAll()
				.WhereIf(!input.Keyword.IsNullOrWhiteSpace(), x => x.Ad.Contains(input.Keyword))
				.WhereIf(input.IsActive.HasValue, x => x.AktifMi == input.IsActive)
				.AsQueryable();

			return data;
		}

		public async Task<List<BirimDto>> GetAllAsyncDto(PagedBirimResultRequestDto input)
		{
			var data = await _repository.GetAllListAsync(a => a.AktifMi == input.IsActive);
			var mapData = ObjectMapper.Map<List<BirimDto>>(data.OrderBy(a => a.SiraNo));

			return mapData;
		}

	}
}
