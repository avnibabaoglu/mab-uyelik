using Abp.AutoMapper;
using Hudayim.Uyelik.Roles.Dto;
using Hudayim.Uyelik.Web.Models.Common;

namespace Hudayim.Uyelik.Web.Models.Roles
{
    [AutoMapFrom(typeof(GetRoleForEditOutput))]
    public class EditRoleModalViewModel : GetRoleForEditOutput, IPermissionsEditViewModel
    {
        public bool HasPermission(FlatPermissionDto permission)
        {
            return GrantedPermissionNames.Contains(permission.Name);
        }
    }
}
