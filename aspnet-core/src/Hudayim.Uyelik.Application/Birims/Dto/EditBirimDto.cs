using Abp.Application.Services.Dto;

namespace Hudayim.Uyelik.Birims.Dto
{
	public class EditBirimDto : CreateBirimDto, IEntityDto<int>
	{
		public int Id { get; set; }
	}
}
