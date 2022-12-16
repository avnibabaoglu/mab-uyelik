using Abp.Application.Services.Dto;

namespace Hudayim.Uyelik.Mesleks.Dto
{
	public class EditMeslekDto : CreateMeslekDto, IEntityDto<int>
	{
		public int Id { get; set; }
	}
}
