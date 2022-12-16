using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Hudayim.Uyelik.Gelirs.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hudayim.Uyelik.Gelirs
{
	public interface IGelirAppService : IAsyncCrudAppService<GelirDto, int, PagedGelirResultRequestDto, CreateGelirDto, GelirDto>
	{
		Task<List<GelirDto>> GetAllAsyncDto(PagedGelirResultRequestDto input);
		Task<GelirDto> GetAsyncDto(EntityDto<int> id);
	}
}
