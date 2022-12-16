using Abp.Application.Services.Dto;

namespace Hudayim.Uyelik.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

