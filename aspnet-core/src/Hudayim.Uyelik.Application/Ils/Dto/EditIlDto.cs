using Abp.Application.Services.Dto;

namespace Hudayim.Uyelik.Ils.Dto
{
	public class EditIlDto : CreateIlDto, IEntityDto<int>
	{
		public int Id { get; set; }
	}
}
