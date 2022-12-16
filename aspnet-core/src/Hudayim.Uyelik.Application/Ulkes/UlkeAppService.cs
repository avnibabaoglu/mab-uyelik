using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Hudayim.Uyelik.Entities;
using Hudayim.Uyelik.Ulkes.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hudayim.Uyelik.Ulkes
{
	[AbpAuthorize]
	public class UlkeAppService : AsyncCrudAppService<Ulke, UlkeDto, int, PagedUlkeResultRequestDto, CreateUlkeDto, UlkeDto>, IUlkeAppService
	{
		private readonly IRepository<Ulke, int> _repository;
		public UlkeAppService(IRepository<Ulke, int> repository) : base(repository)
		{
			_repository = repository;
		}

		public override Task<UlkeDto> CreateAsync(CreateUlkeDto input)
		{
			return base.CreateAsync(input);
		}

		public override Task DeleteAsync(EntityDto<int> input)
		{
			return base.DeleteAsync(input);
		}

		public override Task<PagedResultDto<UlkeDto>> GetAllAsync(PagedUlkeResultRequestDto input)
		{
			return base.GetAllAsync(input);
		}

		public override Task<UlkeDto> GetAsync(EntityDto<int> input)
		{
			return base.GetAsync(input);
		}

		public override Task<UlkeDto> UpdateAsync(UlkeDto input)
		{
			return base.UpdateAsync(input);
		}

		protected override Task<Ulke> GetEntityByIdAsync(int id)
		{
			return base.GetEntityByIdAsync(id);
		}
		public async Task<List<UlkeDto>> GetAllAsyncDto(PagedUlkeResultRequestDto input)
		{
			var data = await _repository.GetAllListAsync(a => a.IsDeleted == input.IsDeleted);
			var mapData = ObjectMapper.Map<List<UlkeDto>>(data.OrderBy(a => a.SiraNo));

			return mapData;
		}

	}
}
