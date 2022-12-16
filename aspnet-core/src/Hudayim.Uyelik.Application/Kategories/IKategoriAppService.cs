using Abp.Application.Services;
using Hudayim.Uyelik.Kategories.Dto;
using System.Collections.Generic;

namespace Hudayim.Uyelik.Kategories
{
	public interface IKategoriAppService : IAsyncCrudAppService<KategoriDto, int, PagedKategoriResultRequestDto, CreateKategoriDto, KategoriDto>
	{
		public List<KategoriDto> GetAllAsyncDto(PagedKategoriResultRequestDto input);
	}
}
