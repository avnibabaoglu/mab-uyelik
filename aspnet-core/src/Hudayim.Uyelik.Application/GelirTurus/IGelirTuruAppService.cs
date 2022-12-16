using Abp.Application.Services;
using Hudayim.Uyelik.GelirTurus.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hudayim.Uyelik.GelirTurus
{
	public interface IGelirTuruAppService : IAsyncCrudAppService<GelirTuruDto, int, PagedGelirTuruResultRequestDto, CreateGelirTuruDto, GelirTuruDto>
	{
		Task<List<GelirTuruDto>> GetAllAsyncDto(PagedGelirTuruResultRequestDto input);
	}
}
