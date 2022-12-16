using Abp.Application.Services;
using Hudayim.Uyelik.Universites.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hudayim.Uyelik.Universites
{
	public interface IUniversiteAppService : IAsyncCrudAppService<UniversiteDto, int, PagedUniversiteResultRequestDto, CreateUniversiteDto, UniversiteDto>
	{
		public Task<List<UniversiteDto>> GetAllAsyncDto(PagedUniversiteResultRequestDto input);
	}
}
