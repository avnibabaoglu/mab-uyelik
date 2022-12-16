using AutoMapper;
using Hudayim.Uyelik.Entities;

namespace Hudayim.Uyelik.Universites.Dto
{
	public class UniversiteMapProfile : Profile
	{
		public UniversiteMapProfile()
		{
			CreateMap<UniversiteDto, Universite>()
			.ForMember(x => x.CreationTime, opt => opt.Ignore())
			.ForMember(x => x.CreatorUserId, opt => opt.Ignore());

			CreateMap<CreateUniversiteDto, Universite>();
			CreateMap<EditUniversiteDto, Universite>();

			CreateMap<Universite, UniversiteDto>();
			CreateMap<Universite, CreateUniversiteDto>();
			CreateMap<Universite, EditUniversiteDto>();
		}
	}
}
