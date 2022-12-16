using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Hudayim.Uyelik.Ilces.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hudayim.Uyelik.Ilces
{
	public interface IIlceAppService : IAsyncCrudAppService<IlceDto, int, PagedIlceResultRequestDto, CreateIlceDto, IlceDto>
	{
		public Task<List<IlceDto>> GetAllAsyncDto(PagedIlceResultRequestDto input);
		public Task<IlceDto> GetAsyncDto(EntityDto<int> id);
	}
}
