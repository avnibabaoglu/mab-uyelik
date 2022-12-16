using Abp.Application.Services.Dto;

namespace Hudayim.Uyelik.KullaniciKategorileris.Dto
{
	public class EditKullaniciKategorileriDto : CreateKullaniciKategorileriDto, IEntityDto<int>
	{
		public int Id { get; set; }
	}
}
