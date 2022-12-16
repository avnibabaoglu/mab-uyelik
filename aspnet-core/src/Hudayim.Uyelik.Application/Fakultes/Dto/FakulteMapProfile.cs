using AutoMapper;
using Hudayim.Uyelik.Entities;

namespace Hudayim.Uyelik.Fakultes.Dto
{
	public class FakulteMapProfile : Profile
	{
		public FakulteMapProfile()
		{
			CreateMap<FakulteDto, Fakulte>()
			.ForMember(x => x.CreationTime, opt => opt.Ignore())
			.ForMember(x => x.CreatorUserId, opt => opt.Ignore())
			;
			CreateMap<CreateFakulteDto, Fakulte>();
			CreateMap<EditFakulteDto, Fakulte>();

			CreateMap<Fakulte, FakulteDto>()
			.ForMember(d => d.UniversiteAdi, o => o.MapFrom(s => s.Universite.Ad))
			;

			CreateMap<Fakulte, CreateFakulteDto>();
			CreateMap<Fakulte, EditFakulteDto>();
		}
	}
}
