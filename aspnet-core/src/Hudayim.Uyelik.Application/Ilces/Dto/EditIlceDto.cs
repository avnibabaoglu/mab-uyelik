using Abp.Application.Services.Dto;

namespace Hudayim.Uyelik.Ilces.Dto
{
	public class EditIlceDto : CreateIlceDto, IEntityDto<int>
	{
		public int Id { get; set; }
	}
}
