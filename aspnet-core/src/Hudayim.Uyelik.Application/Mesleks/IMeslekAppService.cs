using Abp.Application.Services;
using Hudayim.Uyelik.Mesleks.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hudayim.Uyelik.Mesleks
{
	public interface IMeslekAppService : IAsyncCrudAppService<MeslekDto, int, PagedMeslekResultRequestDto, CreateMeslekDto, MeslekDto>
	{
		public Task<List<MeslekDto>> GetAllAsyncDto(PagedMeslekResultRequestDto input);
	}
}
