using Abp.Application.Services.Dto;

namespace Hudayim.Uyelik.Kategories.Dto
{
	public class EditKategoriDto : CreateKategoriDto, IEntityDto<int>
	{
		public int Id { get; set; }
	}
}
