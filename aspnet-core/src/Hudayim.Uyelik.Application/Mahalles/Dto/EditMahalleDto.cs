using Abp.Application.Services.Dto;

namespace Hudayim.Uyelik.Mahalles.Dto
{
	public class EditMahalleDto : CreateMahalleDto, IEntityDto<int>
	{
		public int Id { get; set; }
	}
}
