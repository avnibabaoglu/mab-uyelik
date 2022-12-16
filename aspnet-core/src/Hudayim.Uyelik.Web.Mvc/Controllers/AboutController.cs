using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using Hudayim.Uyelik.Controllers;

namespace Hudayim.Uyelik.Web.Controllers
{
    [AbpMvcAuthorize]
    public class AboutController : UyelikControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
