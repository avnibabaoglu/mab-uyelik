using Abp.Application.Services.Dto;

namespace Hudayim.Uyelik.Donems.Dto
{
	public class EditDonemDto : CreateDonemDto, IEntityDto<int>
	{
		public int Id { get; set; }

	}
}
