using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Hudayim.Uyelik.Entities;
using Hudayim.Uyelik.Firmas.Dto;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hudayim.Uyelik.Firmas
{
	[AbpAuthorize]
	public class FirmaAppService : AsyncCrudAppService<Firma, FirmaDto, int, PagedFirmaResultRequestDto, CreateFirmaDto, FirmaDto>, IFirmaAppService
	{
		private readonly IRepository<Firma, int> _repository;
		public FirmaAppService(IRepository<Firma, int> repository) : base(repository)
		{
			_repository = repository;
		}

		protected override IQueryable<Firma> CreateFilteredQuery(PagedFirmaResultRequestDto input)
		{
			var data = Repository.GetAllIncluding()
				.Include(a => a.Il)
				.Include(a => a.Kategori)
				.Where(a => !a.IsDeleted)
				.WhereIf(!input.Keyword.IsNullOrWhiteSpace(), x => x.Ad.Contains(input.Keyword))
				.WhereIf(input.KategoriId.HasValue, x => x.KategoriId == input.KategoriId)
				.WhereIf(input.IlId.HasValue, x => x.IlId == input.IlId)
				.AsQueryable();

			return data;
		}
		public async Task<List<FirmaDto>> GetAllAsyncDto(PagedFirmaResultRequestDto input)
		{
			var data = CreateFilteredQuery(input);
			var mapData = ObjectMapper.Map<List<FirmaDto>>(await data.OrderBy(a => a.SiraNo).ToListAsync());

			return mapData;
		}

		public async Task<FirmaDto> GetAsyncDto(EntityDto<int> id)
		{
			var data = await Repository.GetAllIncluding().Include(a => a.Kategori).Include(a => a.Il).FirstOrDefaultAsync(a => a.Id == id.Id);
			var mapData = ObjectMapper.Map<FirmaDto>(data);

			return mapData;
		}

	}
}
