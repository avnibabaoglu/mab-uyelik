using AutoMapper;
using Hudayim.Uyelik.Entities;

namespace Hudayim.Uyelik.KullaniciKategorileris.Dto
{
	public class KullaniciKategorileriMapProfile : Profile
	{
		public KullaniciKategorileriMapProfile()
		{
			CreateMap<KullaniciKategorileriDto, KullaniciKategorileri>()
			.ForMember(x => x.CreationTime, opt => opt.Ignore())
			.ForMember(x => x.CreatorUserId, opt => opt.Ignore());

			CreateMap<CreateKullaniciKategorileriDto, KullaniciKategorileri>();
			CreateMap<EditKullaniciKategorileriDto, KullaniciKategorileri>();

			CreateMap<KullaniciKategorileri, KullaniciKategorileriDto>()
				.ForMember(d => d.UserName, o => o.MapFrom(s => $"{s.User.Name} {s.User.Surname}"))
				.ForMember(d => d.KategoriAdi, o => o.MapFrom(s => s.Kategori.Ad))
			;

			CreateMap<KullaniciKategorileri, CreateKullaniciKategorileriDto>();
			CreateMap<KullaniciKategorileri, EditKullaniciKategorileriDto>();
		}
	}
}
