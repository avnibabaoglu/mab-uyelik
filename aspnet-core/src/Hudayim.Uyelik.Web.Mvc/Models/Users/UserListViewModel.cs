using System.Collections.Generic;
using Hudayim.Uyelik.Roles.Dto;

namespace Hudayim.Uyelik.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
