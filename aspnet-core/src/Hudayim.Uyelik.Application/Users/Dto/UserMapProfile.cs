using AutoMapper;
using Hudayim.Uyelik.Authorization.Users;

namespace Hudayim.Uyelik.Users.Dto
{
	public class UserMapProfile : Profile
	{
		public UserMapProfile()
		{
			CreateMap<UserDto, User>();
			CreateMap<UserDto, User>()
				.ForMember(x => x.Roles, opt => opt.Ignore())
				.ForMember(x => x.CreationTime, opt => opt.Ignore())
				.ForMember(x => x.CreatorUserId, opt => opt.Ignore())
			;

			CreateMap<User, UserDto>()
				.ForMember(dto => dto.OkulBilgisi, o => o.MapFrom(src => $"{src.MezunOlduguOkul}/{src.MezunOlduguBolum}"))
				.ForMember(dto => dto.MeslekAdi, o => o.MapFrom(src => src.Meslek.Ad))
				.ForMember(dto => dto.IlAdi, o => o.MapFrom(src => src.Il.Ad))
				.ForMember(dto => dto.IlceAdi, o => o.MapFrom(src => src.Ilce.Ad))
				.ForMember(dto => dto.MahalleAdi, o => o.MapFrom(src => src.Mahalle.Ad))
				.ForMember(dto => dto.UniversiteAdi, o => o.MapFrom(src => src.Universite.Ad))
				.ForMember(dto => dto.FakulteAdi, o => o.MapFrom(src => src.Fakulte.Ad))
				.ForMember(dto => dto.BolumAdi, o => o.MapFrom(src => src.Bolum.Ad))
				.ForMember(dto => dto.ProfilFotografTamYolu, o => o.MapFrom(src => !string.IsNullOrEmpty(src.ProfilFotografYolu) && !string.IsNullOrEmpty(src.ProfilFotografAdi) ?
																						$"\\{src.ProfilFotografYolu}\\{src.ProfilFotografAdi}" : string.Empty))
				;

			CreateMap<CreateUserDto, User>();
			CreateMap<CreateUserDto, User>().ForMember(x => x.Roles, opt => opt.Ignore());
		}
	}
}
