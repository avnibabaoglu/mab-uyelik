using Abp.Application.Services.Dto;

namespace Hudayim.Uyelik.Bolums.Dto
{
	public class EditBolumDto : CreateBolumDto, IEntityDto<int>
	{
		public int Id { get; set; }
	}
}
