using Abp.Configuration.Startup;
using Abp.Data;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.EntityFrameworkCore;
using Abp.Extensions;
using Abp.MultiTenancy;
using Hudayim.Uyelik.EntityFrameworkCore;
using Hudayim.Uyelik.Migrator.Data.EntityFramework.IlanBis;
using Hudayim.Uyelik.Migrator.Data.EntityFramework.Uyelik;
using Hudayim.Uyelik.Migrator.Migrators.Meslek;
using Hudayim.Uyelik.Migrator.Migrators.Uyeler;
using Hudayim.Uyelik.MultiTenancy;
using Microsoft.EntityFrameworkCore;
using System;
using System.Transactions;

namespace Hudayim.Uyelik.Migrator
{
	public class MigrateExecuter : ITransientDependency
	{
		public Log Log { get; private set; }
		private readonly AbpZeroDbMigrator _migrator;
		private readonly IDbPerTenantConnectionStringResolver _connectionStringResolver;
		private readonly IUnitOfWorkManager _unitOfWorkManager;
		private readonly IDbContextResolver _dbContextResolver;
		private readonly IRepository<Tenant> _tenantRepository;
		private readonly IAbpStartupConfiguration _configuration;

		public MigrateExecuter(AbpZeroDbMigrator migrator,
			IRepository<Tenant> tenantRepository,
			Log log,
			IDbPerTenantConnectionStringResolver connectionStringResolver,
			IUnitOfWorkManager unitOfWorkManager,
			IDbContextResolver dbContextResolver,
			IAbpStartupConfiguration configuration)

		{
			Log = log;
			_migrator = migrator;
			_tenantRepository = tenantRepository;
			_connectionStringResolver = connectionStringResolver;
			_unitOfWorkManager = unitOfWorkManager;
			_dbContextResolver = dbContextResolver;
			_configuration = configuration;
		}

		protected virtual void MigrateFromUyelik(MigrationParameter _migrationParameter, AbpTenantBase tenant = null)
		{
			var args = new DbPerTenantConnectionStringResolveArgs(
				tenant == null ? (int?)null : (int?)tenant.Id,
				tenant == null ? MultiTenancySides.Host : MultiTenancySides.Tenant
			);
			var nameOrConnectionString = ConnectionStringHelper.GetConnectionString(
				_connectionStringResolver.GetNameOrConnectionString(args)
			);
			var IBConnectionString = _configuration.Get("ILANBIS").ToString();

			using (var uow = _unitOfWorkManager.Begin(TransactionScopeOption.RequiresNew))
			using (var dbContextIB = new IBDBContext(IBConnectionString))
			using (var dbContextUyelik2 = new UyelikDBContext(nameOrConnectionString))
			using (var dbContextUyelik = _dbContextResolver.Resolve<UyelikDbContext>(nameOrConnectionString, null))
			{
				dbContextUyelik.Database.OpenConnection();
				dbContextIB.Database.OpenConnection();
				dbContextUyelik2.Database.OpenConnection();
				try
				{
					#region Addresses
					if (_migrationParameter.MigrateAddresses)
						new AddressMigrator(dbContextIB, dbContextUyelik, dbContextUyelik2, Log).Migrate();
					#endregion
					#region Üye
					if (_migrationParameter.MigrateUsers)
						new UyeMigrator(dbContextIB, dbContextUyelik, dbContextUyelik2, Log).Migrate();
					#endregion
					#region Meslek
					if (_migrationParameter.MigrateProfession)
						new ProfessionMigrator(dbContextIB, dbContextUyelik, dbContextUyelik2, Log).Migrate();
					#endregion
					#region Üniversite
					if (_migrationParameter.MigrateUniversity)
						new UniversityMigrator(dbContextIB, dbContextUyelik, dbContextUyelik2, Log).Migrate();
					#endregion
					#region Ülkeler
					if (_migrationParameter.MigrateUlkeler)
						new UlkelerMigrator(dbContextIB, dbContextUyelik, dbContextUyelik2, Log).Migrate();
					#endregion
				}
				finally
				{
					dbContextUyelik.Database.CloseConnection();
					dbContextIB.Database.CloseConnection();
					dbContextUyelik2.Database.CloseConnection();
				}
				uow.Complete();
			}

		}
		public bool Run(MigrationParameter _migrationParameter)
		{
			var hostConnStr = _connectionStringResolver.GetNameOrConnectionString(new ConnectionStringResolveArgs(MultiTenancySides.Host));
			if (hostConnStr.IsNullOrWhiteSpace())
			{
				Log.Write("Configuration file should contain a connection string named 'Default'");
				return false;
			}

			if (_migrationParameter.QuietMode != true)
			{
				Log.Write("Start migrating ? (Y/N): ");
				var command = Console.ReadLine();
				if (!command.IsIn("Y", "y"))
				{
					Log.Write("Migration canceled.");
					return false;
				}
			}

			Log.Write("Migration started...");

			try
			{
				MigrateFromUyelik(_migrationParameter);
			}
			catch (Exception ex)
			{
				Log.Write("An error occured during migration:");
				Log.Write(ex.ToString());
				Log.Write("Canceled migrations.");
				var command = Console.ReadLine();
				return false;
			}

			Log.Write("Migration completed.");
			Log.Write("--------------------------------------------------------");
			return true;
		}



	}
}
