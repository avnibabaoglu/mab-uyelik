using AutoMapper;
using Hudayim.Uyelik.Entities;

namespace Hudayim.Uyelik.Bolums.Dto
{
	public class BolumMapProfile : Profile
	{
		public BolumMapProfile()
		{
			CreateMap<BolumDto, Bolum>()
			.ForMember(x => x.CreationTime, opt => opt.Ignore())
			.ForMember(x => x.CreatorUserId, opt => opt.Ignore())
			;

			CreateMap<CreateBolumDto, Bolum>();
			CreateMap<EditBolumDto, Bolum>();

			CreateMap<Bolum, BolumDto>()
			.ForMember(d => d.UniversiteAdi, o => o.MapFrom(s => s.Universite.Ad))
			.ForMember(d => d.FakulteAdi, o => o.MapFrom(s => s.Fakulte.Ad))
			;

			CreateMap<Bolum, CreateBolumDto>();
			CreateMap<Bolum, EditBolumDto>();

		}
	}
}
