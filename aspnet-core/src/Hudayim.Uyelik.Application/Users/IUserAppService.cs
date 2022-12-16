using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Hudayim.Uyelik.Roles.Dto;
using Hudayim.Uyelik.Users.Dto;

namespace Hudayim.Uyelik.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedUserResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);

        Task<bool> ChangePassword(ChangePasswordDto input);
    }
}
