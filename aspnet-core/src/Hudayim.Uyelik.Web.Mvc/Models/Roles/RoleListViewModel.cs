using System.Collections.Generic;
using Hudayim.Uyelik.Roles.Dto;

namespace Hudayim.Uyelik.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}
