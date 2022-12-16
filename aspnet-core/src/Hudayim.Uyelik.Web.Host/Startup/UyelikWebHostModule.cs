using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Hudayim.Uyelik.Configuration;

namespace Hudayim.Uyelik.Web.Host.Startup
{
    [DependsOn(
       typeof(UyelikWebCoreModule))]
    public class UyelikWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public UyelikWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(UyelikWebHostModule).GetAssembly());
        }
    }
}
