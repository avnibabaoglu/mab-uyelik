using AutoMapper;
using Hudayim.Uyelik.Entities;

namespace Hudayim.Uyelik.Mahalles.Dto
{
	public class MahalleMapProfile : Profile
	{
		public MahalleMapProfile()
		{
			CreateMap<MahalleDto, Mahalle>()
			.ForMember(x => x.CreationTime, opt => opt.Ignore())
			.ForMember(x => x.CreatorUserId, opt => opt.Ignore());

			CreateMap<CreateMahalleDto, Mahalle>();
			CreateMap<EditMahalleDto, Mahalle>();

			CreateMap<Mahalle, MahalleDto>()
			.ForMember(d => d.UlkeAdi, o => o.MapFrom(s => s.Ilce.Il.Ulke.Ad))
			.ForMember(d => d.UlkeId, o => o.MapFrom(s => s.Ilce.Il.Ulke.Id))
			.ForMember(d => d.IlAdi, o => o.MapFrom(s => s.Ilce.Il.Ad))
			.ForMember(d => d.IlId, o => o.MapFrom(s => s.Ilce.Il.Id))
			.ForMember(d => d.IlceAdi, o => o.MapFrom(s => s.Ilce.Ad))
			;

			CreateMap<Mahalle, CreateMahalleDto>();
			CreateMap<Mahalle, EditMahalleDto>();
		}
	}
}
