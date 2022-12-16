using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace Hudayim.Uyelik.Controllers
{
	public abstract class UyelikControllerBase: AbpController
    {
        protected UyelikControllerBase()
        {
            LocalizationSourceName = UyelikConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
