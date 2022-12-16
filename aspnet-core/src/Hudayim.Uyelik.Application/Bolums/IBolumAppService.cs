using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Hudayim.Uyelik.Bolums.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hudayim.Uyelik.Bolums
{
	public interface IBolumAppService : IAsyncCrudAppService<BolumDto, int, PagedBolumResultRequestDto, CreateBolumDto, BolumDto>
	{
		public Task<List<BolumDto>> GetAllAsyncDto(PagedBolumResultRequestDto input);
		public Task<BolumDto> GetAsyncDto(EntityDto<int> id);

	}
}
