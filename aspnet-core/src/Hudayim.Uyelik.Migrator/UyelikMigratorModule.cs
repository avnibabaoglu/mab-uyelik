using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Castle.MicroKernel.Registration;
using Hudayim.Uyelik.Configuration;
using Hudayim.Uyelik.EntityFrameworkCore;
using Hudayim.Uyelik.Migrator.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace Hudayim.Uyelik.Migrator
{
	[DependsOn(typeof(UyelikEntityFrameworkModule))]
	public class UyelikMigratorModule : AbpModule
	{
		private readonly IConfigurationRoot _appConfiguration;

		public UyelikMigratorModule(UyelikEntityFrameworkModule abpProjectNameEntityFrameworkModule)
		{
			abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

			_appConfiguration = AppConfigurations.Get(
				typeof(UyelikMigratorModule).GetAssembly().GetDirectoryPathOrNull()
			);
		}

		public override void PreInitialize()
		{
			Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
				UyelikConsts.ConnectionStringName
			);

			Configuration.Set("ILANBIS", _appConfiguration.GetConnectionString("ILANBIS"));

			Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
			Configuration.ReplaceService(
				typeof(IEventBus),
				() => IocManager.IocContainer.Register(
					Component.For<IEventBus>().Instance(NullEventBus.Instance)
				)
			);
		}

		public override void Initialize()
		{
			IocManager.RegisterAssemblyByConvention(typeof(UyelikMigratorModule).GetAssembly());
			ServiceCollectionRegistrar.Register(IocManager);
		}
	}

}
