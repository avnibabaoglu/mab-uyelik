using Abp.Application.Services.Dto;

namespace Hudayim.Uyelik.Universites.Dto
{
	public class EditUniversiteDto : CreateUniversiteDto, IEntityDto<int>
	{
		public int Id { get; set; }
	}
}
