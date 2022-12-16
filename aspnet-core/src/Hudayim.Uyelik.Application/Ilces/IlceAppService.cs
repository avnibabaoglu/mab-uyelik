using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Hudayim.Uyelik.Entities;
using Hudayim.Uyelik.Ilces.Dto;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hudayim.Uyelik.Ilces
{
	[AbpAuthorize]
	public class IlceAppService : AsyncCrudAppService<Ilce, IlceDto, int, PagedIlceResultRequestDto, CreateIlceDto, IlceDto>, IIlceAppService
	{
		private readonly IRepository<Ilce, int> _repository;
		public IlceAppService(IRepository<Ilce, int> repository) : base(repository)
		{
			_repository = repository;
		}

		protected override IQueryable<Ilce> CreateFilteredQuery(PagedIlceResultRequestDto input)
		{
			var data = Repository.GetAllIncluding()
				.Include(a => a.Il)
				.ThenInclude(a => a.Ulke)
				.WhereIf(!input.Keyword.IsNullOrWhiteSpace(), x => x.Ad.Contains(input.Keyword))
				.AsQueryable();

			return data;
		}

		public async Task<List<IlceDto>> GetAllAsyncDto(PagedIlceResultRequestDto input)
		{
			var data = await _repository.GetAllListAsync(a => input.IlId.HasValue ? a.IlId == input.IlId && a.IsDeleted == input.IsDeleted : a.IsDeleted == input.IsDeleted);
			var mapData = ObjectMapper.Map<List<IlceDto>>(data.OrderBy(a => a.SiraNo));

			return mapData;
		}

		public async Task<IlceDto> GetAsyncDto(EntityDto<int> id)
		{
			var data = await Repository.GetAllIncluding()
				.Include(a => a.Il)
				.ThenInclude(a => a.Ulke)
				.FirstOrDefaultAsync(a => a.Id == id.Id);

			var mapData = ObjectMapper.Map<IlceDto>(data);

			return mapData;
		}
	}
}
