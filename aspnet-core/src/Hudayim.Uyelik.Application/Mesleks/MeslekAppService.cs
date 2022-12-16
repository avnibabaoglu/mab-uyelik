using Abp.Application.Services;
using Abp.Authorization;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Hudayim.Uyelik.Entities;
using Hudayim.Uyelik.Mesleks.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hudayim.Uyelik.Mesleks
{
	[AbpAuthorize]
	public class MeslekAppService : AsyncCrudAppService<Meslek, MeslekDto, int, PagedMeslekResultRequestDto, CreateMeslekDto, MeslekDto>, IMeslekAppService
	{
		private readonly IRepository<Meslek, int> _repository;

		public MeslekAppService(IRepository<Meslek, int> repository) : base(repository)
		{
			_repository = repository;
		}

		protected override IQueryable<Meslek> CreateFilteredQuery(PagedMeslekResultRequestDto input)
		{
			var data = Repository.GetAll()
				.WhereIf(!input.Keyword.IsNullOrWhiteSpace(), x => x.Ad.Contains(input.Keyword))
				.WhereIf(input.IsActive.HasValue, x => x.AktifMi == input.IsActive)
				.AsQueryable();

			return data;
		}

		public async Task<List<MeslekDto>> GetAllAsyncDto(PagedMeslekResultRequestDto input)
		{
			var data = await _repository.GetAllListAsync(a => a.AktifMi == input.IsActive && a.Ad.Contains(input.Keyword));
			var mapData = ObjectMapper.Map<List<MeslekDto>>(data.OrderBy(a => a.SiraNo));

			return mapData;
		}
	}
}
