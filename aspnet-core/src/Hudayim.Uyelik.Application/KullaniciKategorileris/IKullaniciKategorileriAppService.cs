using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Hudayim.Uyelik.KullaniciKategorileris.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hudayim.Uyelik.KullaniciKategorileris
{
	public interface IKullaniciKategorileriAppService : IAsyncCrudAppService<KullaniciKategorileriDto, int, PagedKullaniciKategorileriResultRequestDto, CreateKullaniciKategorileriDto, KullaniciKategorileriDto>
	{
		Task<List<KullaniciKategorileriDto>> GetAllAsyncDto(PagedKullaniciKategorileriResultRequestDto input);
		Task<KullaniciKategorileriDto> GetAsyncDto(EntityDto<int> id);
		Task<bool> CreateAsync(long? userId, string[] kategoriIds);
		Task<bool> UpdateAsync(long? userId, string[] kategoriIds);

	}
}
