using Abp.Application.Services;
using Hudayim.Uyelik.Birims.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hudayim.Uyelik.Birims
{
	public interface IBirimAppService : IAsyncCrudAppService<BirimDto, int, PagedBirimResultRequestDto, CreateBirimDto, BirimDto>
	{
		Task<List<BirimDto>> GetAllAsyncDto(PagedBirimResultRequestDto input);
	}
}
