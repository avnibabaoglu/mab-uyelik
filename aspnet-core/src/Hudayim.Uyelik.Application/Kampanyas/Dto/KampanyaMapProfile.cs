using AutoMapper;
using Hudayim.Uyelik.Entities;

namespace Hudayim.Uyelik.Kampanyas.Dto
{
	public class KampanyaMapProfile : Profile
	{
		public KampanyaMapProfile()
		{
			CreateMap<KampanyaDto, Kampanya>()
			.ForMember(x => x.CreationTime, opt => opt.Ignore())
			.ForMember(x => x.CreatorUserId, opt => opt.Ignore());

			CreateMap<CreateKampanyaDto, Kampanya>();
			CreateMap<EditKampanyaDto, Kampanya>();

			CreateMap<Kampanya, KampanyaDto>()
			.ForMember(d => d.FirmaAdi, o => o.MapFrom(s => s.Firma.Ad))
			.ForMember(d => d.FirmaKategoriId, o => o.MapFrom(s => s.Firma.KategoriId))
			.ForMember(d => d.FirmaKategoriAdi, o => o.MapFrom(s => s.Firma.Kategori.Ad))
			.ForMember(d => d.FirmaMailAdresi, o => o.MapFrom(s => s.Firma.Mail))
			.ForMember(d => d.FirmaTelefon, o => o.MapFrom(s => s.Firma.Telefon))
			.ForMember(dto => dto.ResimTamYolu, o => o.MapFrom(src => !string.IsNullOrEmpty(src.ResimYolu) && !string.IsNullOrEmpty(src.ResimAdi) ? $"\\{src.ResimYolu}\\{src.ResimAdi}" : string.Empty))
			;

			CreateMap<Kampanya, CreateKampanyaDto>();
			CreateMap<Kampanya, EditKampanyaDto>();
		}
	}
}
