using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Hudayim.Uyelik.Ils.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hudayim.Uyelik.Ils
{
	public interface IIlAppService : IAsyncCrudAppService<IlDto, int, PagedIlResultRequestDto, CreateIlDto, IlDto>
	{
		public Task<List<IlDto>> GetAllAsyncDto(PagedIlResultRequestDto input);
		public Task<IlDto> GetAsyncDto(EntityDto<int> id);
	}
}
