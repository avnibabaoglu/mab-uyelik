using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Hudayim.Uyelik.Entities;
using Hudayim.Uyelik.Mahalles.Dto;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hudayim.Uyelik.Mahalles
{
	[AbpAuthorize]
	public class MahalleAppService : AsyncCrudAppService<Mahalle, MahalleDto, int, PagedMahalleResultRequestDto, CreateMahalleDto, MahalleDto>, IMahalleAppService
	{
		private readonly IRepository<Mahalle, int> _repository;
		public MahalleAppService(IRepository<Mahalle, int> repository) : base(repository)
		{
			_repository = repository;
		}

		protected override IQueryable<Mahalle> CreateFilteredQuery(PagedMahalleResultRequestDto input)
		{
			var data = Repository.GetAllIncluding()
				.Include(a => a.Ilce)
				.ThenInclude(a => a.Il)
				.ThenInclude(a => a.Ulke)
				.WhereIf(!input.Keyword.IsNullOrWhiteSpace(), x => x.Ad.Contains(input.Keyword))
				.AsQueryable();

			return data;
		}
		public async Task<List<MahalleDto>> GetAllAsyncDto(PagedMahalleResultRequestDto input)
		{
			var data = await _repository.GetAllListAsync(a => input.IlceId.HasValue ? a.IlceId == input.IlceId && a.IsDeleted == input.IsDeleted : a.IsDeleted == input.IsDeleted);
			var mapData = ObjectMapper.Map<List<MahalleDto>>(data.OrderBy(a => a.SiraNo));

			return mapData;
		}

		public async Task<MahalleDto> GetAsyncDto(EntityDto<int> id)
		{
			var data = await Repository.GetAllIncluding()
				.Include(a => a.Ilce)
				.ThenInclude(a => a.Il)
				.ThenInclude(a => a.Ulke)
				.FirstOrDefaultAsync(a => a.Id == id.Id);

			var mapData = ObjectMapper.Map<MahalleDto>(data);

			return mapData;
		}
	}
}
