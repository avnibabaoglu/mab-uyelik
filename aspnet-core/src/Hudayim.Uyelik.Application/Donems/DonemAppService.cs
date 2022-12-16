using Abp.Application.Services;
using Abp.Authorization;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Hudayim.Uyelik.Donems.Dto;
using Hudayim.Uyelik.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hudayim.Uyelik.Donems
{
	[AbpAuthorize]
	public class DonemAppService : AsyncCrudAppService<Donem, DonemDto, int, PagedDonemResultRequestDto, CreateDonemDto, DonemDto>, IDonemAppService
	{
		private readonly IRepository<Donem, int> _repository;
		public DonemAppService(IRepository<Donem, int> repository) : base(repository)
		{
			_repository = repository;
		}
		protected override IQueryable<Donem> CreateFilteredQuery(PagedDonemResultRequestDto input)
		{
			var data = Repository.GetAllIncluding()
				.WhereIf(input.DonemTuru.HasValue, x => x.DonemTuru == input.DonemTuru)
				.WhereIf(!input.Keyword.IsNullOrWhiteSpace(), x => x.Ad.Contains(input.Keyword))
				.WhereIf(input.IsActive.HasValue, x => x.AktifMi == input.IsActive)
				.AsQueryable();

			return data;
		}

		public List<DonemDto> GetAllAsyncDto(PagedDonemResultRequestDto input)
		{
			var data = CreateFilteredQuery(input);
			var mapData = ObjectMapper.Map<List<DonemDto>>(data.OrderBy(a => a.SiraNo));

			return mapData;
		}

	}
}
