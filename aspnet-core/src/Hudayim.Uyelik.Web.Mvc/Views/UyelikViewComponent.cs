using Abp.AspNetCore.Mvc.ViewComponents;

namespace Hudayim.Uyelik.Web.Views
{
    public abstract class UyelikViewComponent : AbpViewComponent
    {
        protected UyelikViewComponent()
        {
            LocalizationSourceName = UyelikConsts.LocalizationSourceName;
        }
    }
}
