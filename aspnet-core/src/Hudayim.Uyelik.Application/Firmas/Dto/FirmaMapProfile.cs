using AutoMapper;
using Hudayim.Uyelik.Entities;

namespace Hudayim.Uyelik.Firmas.Dto
{
	public class FirmaMapProfile : Profile
	{
		public FirmaMapProfile()
		{
			CreateMap<FirmaDto, Firma>()
			.ForMember(x => x.CreationTime, opt => opt.Ignore())
			.ForMember(x => x.CreatorUserId, opt => opt.Ignore());
			CreateMap<CreateFirmaDto, Firma>();
			CreateMap<EditFirmaDto, Firma>();

			CreateMap<Firma, FirmaDto>()
			.ForMember(d => d.IlAdi, o => o.MapFrom(s => s.Il.Ad))
			.ForMember(d => d.KategoriAdi, o => o.MapFrom(s => s.Kategori.Ad))
			.ForMember(dto => dto.ResimTamYolu, o => o.MapFrom(src => !string.IsNullOrEmpty(src.ResimYolu) && !string.IsNullOrEmpty(src.ResimAdi) ? $"\\{src.ResimYolu}\\{src.ResimAdi}" : string.Empty))
			;

			CreateMap<Firma, CreateFirmaDto>();
			CreateMap<Firma, EditFirmaDto>();
		}
	}
}
