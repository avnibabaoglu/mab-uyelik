using Abp.Application.Services.Dto;
using Hudayim.Uyelik.Mahalles.Dto;

namespace Hudayim.Uyelik.Ulkes.Dto
{
	public class EditUlkeDto : CreateMahalleDto, IEntityDto<int>
	{
		public int Id { get; set; }
	}
}
