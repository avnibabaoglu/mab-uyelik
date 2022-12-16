using AutoMapper;
using Hudayim.Uyelik.Entities;

namespace Hudayim.Uyelik.Mesleks.Dto
{
	public class MeslekMapProfile : Profile
	{
		public MeslekMapProfile()
		{
			CreateMap<MeslekDto, Meslek>()
			.ForMember(x => x.CreationTime, opt => opt.Ignore())
			.ForMember(x => x.CreatorUserId, opt => opt.Ignore());

			CreateMap<CreateMeslekDto, Meslek>();
			CreateMap<EditMeslekDto, Meslek>();

			CreateMap<Meslek, MeslekDto>();
			CreateMap<Meslek, CreateMeslekDto>();
			CreateMap<Meslek, EditMeslekDto>();

		}
	}
}
