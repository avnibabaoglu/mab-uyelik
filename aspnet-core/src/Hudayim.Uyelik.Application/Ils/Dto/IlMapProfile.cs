using AutoMapper;
using Hudayim.Uyelik.Entities;

namespace Hudayim.Uyelik.Ils.Dto
{
	public class IlMapProfile : Profile
	{
		public IlMapProfile()
		{
			CreateMap<IlDto, Il>()
			.ForMember(x => x.CreationTime, opt => opt.Ignore())
			.ForMember(x => x.CreatorUserId, opt => opt.Ignore());
			
			CreateMap<CreateIlDto, Il>();
			CreateMap<EditIlDto, Il>();

			CreateMap<Il, IlDto>()
			.ForMember(d => d.UlkeAdi, o => o.MapFrom(s => s.Ulke.Ad))
			;

			CreateMap<Il, CreateIlDto>();
			CreateMap<Il, EditIlDto>();
		}
	}
}
