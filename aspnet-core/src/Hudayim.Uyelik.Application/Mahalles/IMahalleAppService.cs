using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Hudayim.Uyelik.Mahalles.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hudayim.Uyelik.Mahalles
{
	public interface IMahalleAppService : IAsyncCrudAppService<MahalleDto, int, PagedMahalleResultRequestDto, CreateMahalleDto, MahalleDto>
	{
		public Task<List<MahalleDto>> GetAllAsyncDto(PagedMahalleResultRequestDto input);
		public Task<MahalleDto> GetAsyncDto(EntityDto<int> id);
	}
}
