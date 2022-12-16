using Abp.Application.Services;
using Hudayim.Uyelik.Donems.Dto;
using System.Collections.Generic;

namespace Hudayim.Uyelik.Donems
{
	public interface IDonemAppService : IAsyncCrudAppService<DonemDto, int, PagedDonemResultRequestDto, CreateDonemDto, DonemDto>
	{
		List<DonemDto> GetAllAsyncDto(PagedDonemResultRequestDto input);
	}
}
