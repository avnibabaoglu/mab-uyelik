using Abp.Application.Services.Dto;

namespace Hudayim.Uyelik.Kampanyas.Dto
{
	public class EditKampanyaDto : CreateKampanyaDto, IEntityDto<int>
	{
		public int Id { get; set; }
	}
}
