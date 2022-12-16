using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Hudayim.Uyelik.Fakultes.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hudayim.Uyelik.Fakultes
{
	public interface IFakulteAppService : IAsyncCrudAppService<FakulteDto, int, PagedFakulteResultRequestDto, CreateFakulteDto, FakulteDto>
	{
		public Task<List<FakulteDto>> GetAllAsyncDto(PagedFakulteResultRequestDto input);
		public Task<FakulteDto> GetAsyncDto(EntityDto<int> id);

	}
}
