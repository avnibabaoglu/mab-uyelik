using Abp.Authorization;
using Hudayim.Uyelik.Authorization.Roles;
using Hudayim.Uyelik.Authorization.Users;

namespace Hudayim.Uyelik.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
