using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Hudayim.Uyelik.Kampanyas.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hudayim.Uyelik.Kampanyas
{
	public interface IKampanyaAppService : IAsyncCrudAppService<KampanyaDto, int, PagedKampanyaResultRequestDto, CreateKampanyaDto, KampanyaDto>
	{
		public Task<List<KampanyaDto>> GetAllAsyncDto(PagedKampanyaResultRequestDto input);
		public Task<KampanyaDto> GetAsyncDto(EntityDto<int> id);
	}
}
