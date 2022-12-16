using AutoMapper;
using Hudayim.Uyelik.Entities;

namespace Hudayim.Uyelik.Ilces.Dto
{
	public class IlceMapProfile : Profile
	{
		public IlceMapProfile()
		{
			CreateMap<IlceDto, Ilce>()
			.ForMember(x => x.CreationTime, opt => opt.Ignore())
			.ForMember(x => x.CreatorUserId, opt => opt.Ignore());

			CreateMap<CreateIlceDto, Ilce>();
			CreateMap<EditIlceDto, Ilce>();

			CreateMap<Ilce, IlceDto>()
			.ForMember(d => d.UlkeAdi, o => o.MapFrom(s => s.Il.Ulke.Ad))
			.ForMember(d => d.UlkeId, o => o.MapFrom(s => s.Il.Ulke.Id))
			.ForMember(d => d.IlAdi, o => o.MapFrom(s => s.Il.Ad))
			.ForMember(d => d.IlId, o => o.MapFrom(s => s.Il.Id))
			;

			CreateMap<Ilce, CreateIlceDto>();
			CreateMap<Ilce, EditIlceDto>();

		}
	}
}
