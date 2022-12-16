using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace Hudayim.Uyelik.Web.Views
{
    public abstract class UyelikRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected UyelikRazorPage()
        {
            LocalizationSourceName = UyelikConsts.LocalizationSourceName;
        }
    }
}
