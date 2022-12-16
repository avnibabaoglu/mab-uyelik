using AutoMapper;
using Hudayim.Uyelik.Entities;

namespace Hudayim.Uyelik.Birims.Dto
{
	public class BirimMapProfile : Profile
	{
		public BirimMapProfile()
		{
			CreateMap<BirimDto, Birim>()
				.ForMember(x => x.CreationTime, opt => opt.Ignore())
				.ForMember(x => x.CreatorUserId, opt => opt.Ignore())
			;

			CreateMap<CreateBirimDto, Birim>();
			CreateMap<EditBirimDto, Birim>();

			CreateMap<Birim, BirimDto>();
			CreateMap<Birim, CreateBirimDto>();
			CreateMap<Birim, EditBirimDto>();
		}
	}
}
