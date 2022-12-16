using Abp.Application.Services.Dto;

namespace Hudayim.Uyelik.KullaniciKategorileris.Dto
{
	public class PagedKullaniciKategorileriResultRequestDto : PagedResultRequestDto
	{
		public string Keyword { get; set; }
		public long? UserId { get; set; }
		public int? KategoriId { get; set; }

	}
}
