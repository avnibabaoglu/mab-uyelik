using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Hudayim.Uyelik.Entities;
using Hudayim.Uyelik.Kampanyas.Dto;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hudayim.Uyelik.Kampanyas
{
	[AbpAuthorize]
	public class KampanyaAppService : AsyncCrudAppService<Kampanya, KampanyaDto, int, PagedKampanyaResultRequestDto, CreateKampanyaDto, KampanyaDto>, IKampanyaAppService
	{
		private readonly IRepository<Kampanya, int> _repository;
		public KampanyaAppService(IRepository<Kampanya, int> repository) : base(repository)
		{
			_repository = repository;
		}

		protected override IQueryable<Kampanya> CreateFilteredQuery(PagedKampanyaResultRequestDto input)
		{
			var data = Repository.GetAllIncluding()
				.Include(a => a.Firma)
				.WhereIf(!input.Keyword.IsNullOrWhiteSpace(), x => x.Ad.Contains(input.Keyword))
				.AsQueryable();

			return data;
		}

		public async Task<List<KampanyaDto>> GetAllAsyncDto(PagedKampanyaResultRequestDto input)
		{
			var data = await _repository.GetAllListAsync(a => input.FirmaId.HasValue ? a.FirmaId == input.FirmaId && a.IsDeleted == input.IsDeleted : a.IsDeleted == input.IsDeleted);
			var mapData = ObjectMapper.Map<List<KampanyaDto>>(data.OrderBy(a => a.SiraNo));
			return mapData;
		}

		public async Task<KampanyaDto> GetAsyncDto(EntityDto<int> id)
		{
			var data = await Repository.GetAllIncluding()
				.Include(a => a.Firma)
				.FirstOrDefaultAsync(a => a.Id == id.Id);

			var mapData = ObjectMapper.Map<KampanyaDto>(data);

			return mapData;
		}
	}
}