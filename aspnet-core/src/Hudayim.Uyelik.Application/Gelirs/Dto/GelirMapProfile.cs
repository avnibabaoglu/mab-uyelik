using AutoMapper;
using Hudayim.Uyelik.Entities;

namespace Hudayim.Uyelik.Gelirs.Dto
{
	public class GelirMapProfile : Profile
	{
		public GelirMapProfile()
		{
			CreateMap<GelirDto, Gelir>()
			.ForMember(x => x.CreationTime, opt => opt.Ignore())
			.ForMember(x => x.CreatorUserId, opt => opt.Ignore());

			CreateMap<CreateGelirDto, Gelir>();
			CreateMap<EditGelirDto, Gelir>();

			CreateMap<Gelir, GelirDto>()
				.ForMember(d => d.UserName, o => o.MapFrom(s => $"{s.User.Name} {s.User.Surname}"))
				.ForMember(d => d.DonemAdi, o => o.MapFrom(s => s.Donem.Ad))
				.ForMember(d => d.GelirTuruAdi, o => o.MapFrom(s => s.GelirTuru.Ad))
			;

			CreateMap<Gelir, CreateGelirDto>();
			CreateMap<Gelir, EditGelirDto>();

		}
	}
}
