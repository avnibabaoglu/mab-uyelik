using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Hudayim.Uyelik.Entities;
using Hudayim.Uyelik.Fakultes.Dto;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hudayim.Uyelik.Fakultes
{
	[AbpAuthorize]
	public class FakulteAppService : AsyncCrudAppService<Fakulte, FakulteDto, int, PagedFakulteResultRequestDto, CreateFakulteDto, FakulteDto>, IFakulteAppService
	{
		private readonly IRepository<Fakulte, int> _repository;

		public FakulteAppService(IRepository<Fakulte, int> repository) : base(repository)
		{
			_repository = repository;
		}

		protected override IQueryable<Fakulte> CreateFilteredQuery(PagedFakulteResultRequestDto input)
		{
			var data = Repository.GetAllIncluding()
				.Include(a => a.Universite)
				.WhereIf(!input.Keyword.IsNullOrWhiteSpace(), x => x.Ad.Contains(input.Keyword))
				.AsQueryable();

			return data;
		}
		public async Task<List<FakulteDto>> GetAllAsyncDto(PagedFakulteResultRequestDto input)
		{

			var data = input.UniversiteId.HasValue ? await _repository.GetAllListAsync(a => a.UniversiteId == input.UniversiteId && a.IsDeleted == input.IsDeleted)
												: await _repository.GetAllListAsync(a => a.IsDeleted == input.IsDeleted);

			var mapData = ObjectMapper.Map<List<FakulteDto>>(data.OrderBy(a => a.SiraNo));

			return mapData;
		}

		public async Task<FakulteDto> GetAsyncDto(EntityDto<int> id)
		{
			var data = await Repository.GetAllIncluding()
				.Include(a => a.Universite)
				.FirstOrDefaultAsync(a => a.Id == id.Id);

			var mapData = ObjectMapper.Map<FakulteDto>(data);

			return mapData;
		}

	}
}
