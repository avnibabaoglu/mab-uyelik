using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Hudayim.Uyelik.Entities;
using Hudayim.Uyelik.Ils.Dto;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hudayim.Uyelik.Ils
{
	[AbpAuthorize]
	public class IlAppService : AsyncCrudAppService<Il, IlDto, int, PagedIlResultRequestDto, CreateIlDto, IlDto>, IIlAppService
	{
		private readonly IRepository<Il, int> _repository;

		public IlAppService(IRepository<Il, int> repository) : base(repository)
		{
			_repository = repository;
		}
		protected override IQueryable<Il> CreateFilteredQuery(PagedIlResultRequestDto input)
		{
			var data = Repository.GetAllIncluding()
				.Include(a => a.Ulke)
				.WhereIf(!input.Keyword.IsNullOrWhiteSpace(), x => x.Ad.Contains(input.Keyword))
				.AsQueryable();

			return data;
		}
		
		public async Task<List<IlDto>> GetAllAsyncDto(PagedIlResultRequestDto input)
		{
			var data = await _repository.GetAllListAsync(a => input.UlkeId.HasValue ? a.UlkeId == input.UlkeId && a.IsDeleted == input.IsDeleted : a.IsDeleted == input.IsDeleted);
			var mapData = ObjectMapper.Map<List<IlDto>>(data.OrderBy(a => a.SiraNo));
			return mapData;
		}

		public async Task<IlDto> GetAsyncDto(EntityDto<int> id)
		{
			var data = await Repository.GetAllIncluding()
				.Include(a => a.Ulke)
				.FirstOrDefaultAsync(a => a.Id == id.Id);

			var mapData = ObjectMapper.Map<IlDto>(data);

			return mapData;
		}

	}
}
