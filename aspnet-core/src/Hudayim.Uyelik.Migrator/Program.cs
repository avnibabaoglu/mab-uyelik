using Abp;
using Abp.Castle.Logging.Log4Net;
using Abp.Collections.Extensions;
using Abp.Dependency;
using Castle.Facilities.Logging;
using System;

namespace Hudayim.Uyelik.Migrator
{
	public class Program
	{

		private static MigrationParameter _migrationParameter = new MigrationParameter();

		public static void Main(string[] args)
		{
			ParseArgs(args);
			var migrationSucceeded = false;

			using (var bootstrapper = AbpBootstrapper.Create<UyelikMigratorModule>())
			{
				bootstrapper.IocManager.IocContainer
					.AddFacility<LoggingFacility>(
						f => f.UseAbpLog4Net().WithConfig("log4net.config")
					);

				bootstrapper.Initialize();


				if (_migrationParameter.MigrateUyelik)
					using (var migrateExecuter = bootstrapper.IocManager.ResolveAsDisposable<MigrateExecuter>())
						migrationSucceeded = migrateExecuter.Object.Run(_migrationParameter);
				else
					using (var migrateExecuter = bootstrapper.IocManager.ResolveAsDisposable<MultiTenantMigrateExecuter>())
						migrationSucceeded = migrateExecuter.Object.Run(_migrationParameter.QuietMode);


				if (_migrationParameter.QuietMode)
				{
					var exitCode = Convert.ToInt32(!migrationSucceeded);
					Environment.Exit(exitCode);
				}
				else
				{
					Console.WriteLine("Press ENTER to exit...");
					Console.ReadLine();
				}

			}
		}

		private static void ParseArgs(string[] args)
		{
			if (args.IsNullOrEmpty())
			{
				return;
			}

			foreach (var arg in args)
			{
				switch (arg)
				{
					case "-q":
						_migrationParameter.QuietMode = true;
						break;
					case "-uyelik":
						_migrationParameter.MigrateUyelik = true;
						break;
					case "-address":
						_migrationParameter.MigrateAddresses = true;
						break;
					case "-uye":
						_migrationParameter.MigrateUsers = true;
						break;
					case "-meslek":
						_migrationParameter.MigrateProfession = true;
						break;
					case "-universite":
						_migrationParameter.MigrateUniversity = true;
						break;
					case "-ulke":
						_migrationParameter.MigrateUlkeler = true;
						break;
					case "-all":
						_migrationParameter.MigrateAddresses = true;
						break;
				}
			}
		}
	}

}
