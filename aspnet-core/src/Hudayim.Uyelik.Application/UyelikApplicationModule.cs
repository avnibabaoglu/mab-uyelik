using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Hudayim.Uyelik.Authorization;

namespace Hudayim.Uyelik
{
    [DependsOn(
        typeof(UyelikCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class UyelikApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<UyelikAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(UyelikApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
