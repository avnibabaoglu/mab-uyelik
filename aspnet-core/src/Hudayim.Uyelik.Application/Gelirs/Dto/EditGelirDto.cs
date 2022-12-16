using Abp.Application.Services.Dto;

namespace Hudayim.Uyelik.Gelirs.Dto
{
	public class EditGelirDto : CreateGelirDto, IEntityDto<int>
	{
		public int Id { get; set; }
	}
}
