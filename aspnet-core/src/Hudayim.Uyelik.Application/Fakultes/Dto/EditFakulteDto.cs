using Abp.Application.Services.Dto;

namespace Hudayim.Uyelik.Fakultes.Dto
{
	public class EditFakulteDto : CreateFakulteDto, IEntityDto<int>
	{
		public int Id { get; set; }
	}
}
