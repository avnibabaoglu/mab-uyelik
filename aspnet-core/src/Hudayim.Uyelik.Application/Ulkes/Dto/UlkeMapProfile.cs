using AutoMapper;
using Hudayim.Uyelik.Entities;

namespace Hudayim.Uyelik.Ulkes.Dto
{
	public class UlkeMapProfile : Profile
	{
		public UlkeMapProfile()
		{
			CreateMap<UlkeDto, Ulke>()
			.ForMember(x => x.CreationTime, opt => opt.Ignore())
			.ForMember(x => x.CreatorUserId, opt => opt.Ignore());

			CreateMap<CreateUlkeDto, Ulke>();
			CreateMap<EditUlkeDto, Ulke>();

			CreateMap<Ulke, UlkeDto>();
			CreateMap<Ulke, CreateUlkeDto>();
			CreateMap<Ulke, EditUlkeDto>();
		}
	}
}
