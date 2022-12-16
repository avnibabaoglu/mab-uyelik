using AutoMapper;
using Hudayim.Uyelik.Entities;

namespace Hudayim.Uyelik.GelirTurus.Dto
{
	public class GelirTuruMapProfile : Profile
	{
		public GelirTuruMapProfile()
		{
			CreateMap<GelirTuruDto, GelirTuru>();
			CreateMap<CreateGelirTuruDto, GelirTuru>();
			CreateMap<EditGelirTuruDto, GelirTuru>();

			CreateMap<GelirTuru, GelirTuruDto>();
			CreateMap<GelirTuru, CreateGelirTuruDto>();
			CreateMap<GelirTuru, EditGelirTuruDto>();

		}
	}
}
