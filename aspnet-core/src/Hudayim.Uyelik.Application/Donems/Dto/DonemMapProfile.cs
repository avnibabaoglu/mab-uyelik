using AutoMapper;
using Hudayim.Uyelik.Entities;
using Hudayim.Uyelik.Entities.Enums;

namespace Hudayim.Uyelik.Donems.Dto
{
	public class DonemMapProfile : Profile
	{
		public DonemMapProfile()
		{
			CreateMap<DonemDto, Donem>()
			.ForMember(x => x.CreationTime, opt => opt.Ignore())
			.ForMember(x => x.CreatorUserId, opt => opt.Ignore())
			;

			CreateMap<CreateDonemDto, Donem>();
			CreateMap<EditDonemDto, Donem>();

			CreateMap<Donem, DonemDto>()
			.ForMember(dst => dst.DonemTuruAdi, opts => opts.MapFrom(src => src.DonemTuru == DonemTuruEnum.Gelir ? "Gelir" :
																			src.DonemTuru == DonemTuruEnum.Mezun ? "Mezun" :
																			src.DonemTuru == DonemTuruEnum.Diger ? "Diğer" : "-"))
			;

			CreateMap<Donem, CreateDonemDto>();
			CreateMap<Donem, EditDonemDto>();

		}

		//.ForMember(d => d.UlkeAdi, o => o.MapFrom(s => s.Ulke.Ad))

	}
}
