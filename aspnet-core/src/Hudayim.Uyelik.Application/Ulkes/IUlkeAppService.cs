using Abp.Application.Services;
using Hudayim.Uyelik.Ulkes.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hudayim.Uyelik.Ulkes
{
	public interface IUlkeAppService : IAsyncCrudAppService<UlkeDto, int, PagedUlkeResultRequestDto, CreateUlkeDto, UlkeDto>
	{
		Task<List<UlkeDto>> GetAllAsyncDto(PagedUlkeResultRequestDto input);
	}
}
