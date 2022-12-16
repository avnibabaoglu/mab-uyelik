using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Hudayim.Uyelik.Bolums.Dto;
using Hudayim.Uyelik.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hudayim.Uyelik.Bolums
{
	[AbpAuthorize]
	public class BolumAppService : AsyncCrudAppService<Bolum, BolumDto, int, PagedBolumResultRequestDto, CreateBolumDto, BolumDto>, IBolumAppService
	{
		private readonly IRepository<Bolum, int> _repository;

		public BolumAppService(IRepository<Bolum, int> repository) : base(repository)
		{
			_repository = repository;
		}

		protected override IQueryable<Bolum> CreateFilteredQuery(PagedBolumResultRequestDto input)
		{
			var data = Repository.GetAllIncluding()
						.Include(a => a.Fakulte)
						.ThenInclude(a => a.Universite)
						.WhereIf(!input.Keyword.IsNullOrWhiteSpace(), x => x.Ad.Contains(input.Keyword))
						.AsQueryable();

			return data;
		}
		public async Task<List<BolumDto>> GetAllAsyncDto(PagedBolumResultRequestDto input)
		{
			var data = input.FakulteId.HasValue ? await _repository.GetAllListAsync(a => a.FakulteId == input.FakulteId && a.IsDeleted == input.IsDeleted)
												: await _repository.GetAllListAsync(a => a.IsDeleted == input.IsDeleted);

			var mapData = ObjectMapper.Map<List<BolumDto>>(data.OrderBy(a => a.SiraNo));

			return mapData;
		}

		public async Task<BolumDto> GetAsyncDto(EntityDto<int> id)
		{
			var data = await Repository.GetAllIncluding()
				.Include(a => a.Fakulte)
				.ThenInclude(a => a.Universite)
				.FirstOrDefaultAsync(a => a.Id == id.Id);

			var mapData = ObjectMapper.Map<BolumDto>(data);

			return mapData;
		}

	}
}
