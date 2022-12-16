using System.Collections.Generic;
using Hudayim.Uyelik.Roles.Dto;

namespace Hudayim.Uyelik.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}