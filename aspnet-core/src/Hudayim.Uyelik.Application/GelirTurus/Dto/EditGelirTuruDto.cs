using Abp.Application.Services.Dto;

namespace Hudayim.Uyelik.GelirTurus.Dto
{
	public class EditGelirTuruDto : CreateGelirTuruDto, IEntityDto<int>
	{
		public int Id { get; set; }
	}
}
