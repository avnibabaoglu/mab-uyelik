using AutoMapper;
using Hudayim.Uyelik.Entities;
using Hudayim.Uyelik.Entities.Enums;

namespace Hudayim.Uyelik.Kategories.Dto
{
	public class KategoriMapProfile : Profile
	{
		public KategoriMapProfile()
		{
			CreateMap<KategoriDto, Kategori>()
			.ForMember(x => x.CreationTime, opt => opt.Ignore())
			.ForMember(x => x.CreatorUserId, opt => opt.Ignore());

			CreateMap<CreateKategoriDto, Kategori>();
			CreateMap<EditKategoriDto, Kategori>();

			CreateMap<Kategori, KategoriDto>()
			.ForMember(dst => dst.KategoriTuruAdi, opts => opts.MapFrom(src => src.KategoriTuru == KategoriTuruEnum.Kullanici ? "Kullanıcı" :
																				src.KategoriTuru == KategoriTuruEnum.Firma ? "Firma" :
																				src.KategoriTuru == KategoriTuruEnum.Diger ? "Diğer" : "-"))
			;

			CreateMap<Kategori, CreateKategoriDto>();
			CreateMap<Kategori, EditKategoriDto>();
		}
	}
}
