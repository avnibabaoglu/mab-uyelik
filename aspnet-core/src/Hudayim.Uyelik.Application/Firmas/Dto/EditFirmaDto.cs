using Abp.Application.Services.Dto;

namespace Hudayim.Uyelik.Firmas.Dto
{
	public class EditFirmaDto : CreateFirmaDto, IEntityDto<int>
	{
		public int Id { get; set; }
	}
}
