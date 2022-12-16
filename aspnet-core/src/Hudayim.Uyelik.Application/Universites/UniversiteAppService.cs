using Abp.Application.Services;
using Abp.Authorization;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Hudayim.Uyelik.Entities;
using Hudayim.Uyelik.Universites;
using Hudayim.Uyelik.Universites.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hudayim.Uyelik.Ils
{
	[AbpAuthorize]
	public class UniversiteAppService : AsyncCrudAppService<Universite, UniversiteDto, int, PagedUniversiteResultRequestDto, CreateUniversiteDto, UniversiteDto>, IUniversiteAppService
	{
		private readonly IRepository<Universite, int> _repository;

		public UniversiteAppService(IRepository<Universite, int> repository) : base(repository)
		{
			_repository = repository;
		}

		protected override IQueryable<Universite> CreateFilteredQuery(PagedUniversiteResultRequestDto input)
		{
			var data = Repository.GetAll()
				.WhereIf(!input.Keyword.IsNullOrWhiteSpace(), x => x.Ad.Contains(input.Keyword))
				.WhereIf(input.IsActive.HasValue, x => x.AktifMi == input.IsActive)
				.AsQueryable();

			return data;
		}

		public async Task<List<UniversiteDto>> GetAllAsyncDto(PagedUniversiteResultRequestDto input)
		{
			var data = _repository.GetAll()
				.WhereIf(!input.Keyword.IsNullOrWhiteSpace(), x => x.Ad.Contains(input.Keyword))
				.WhereIf(input.IsActive.HasValue, x => x.AktifMi == input.IsActive);

			var mapData = ObjectMapper.Map<List<UniversiteDto>>(data.OrderBy(a => a.SiraNo));

			return mapData;
		}

	}
}
