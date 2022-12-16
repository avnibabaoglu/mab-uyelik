using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Hudayim.Uyelik.Firmas.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hudayim.Uyelik.Firmas
{
	public interface IFirmaAppService : IAsyncCrudAppService<FirmaDto, int, PagedFirmaResultRequestDto, CreateFirmaDto, FirmaDto>
	{
		public Task<List<FirmaDto>> GetAllAsyncDto(PagedFirmaResultRequestDto input);
		public Task<FirmaDto> GetAsyncDto(EntityDto<int> id);
	}
}
