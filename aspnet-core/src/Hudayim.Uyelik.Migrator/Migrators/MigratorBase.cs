using Hudayim.Uyelik.EntityFrameworkCore;
using Hudayim.Uyelik.Migrator.Data.EntityFramework.IlanBis;
using Hudayim.Uyelik.Migrator.Data.EntityFramework.Uyelik;

namespace Hudayim.Uyelik.Migrator.Migrators
{
	public class MigratorBase
	{
		protected Log Log;
		protected IBDBContext dbContextIB;
		protected UyelikDbContext dbContextUyelik;
		protected UyelikDBContext dbContextUyelik2;
		protected string TableName = "";

		public MigratorBase(IBDBContext _dbContextIB, UyelikDbContext _dbContextUyelik, UyelikDBContext _dbContextUyelik2, Log log)
		{
			Log = log;
			dbContextIB = _dbContextIB;
			dbContextUyelik = _dbContextUyelik;
			dbContextUyelik2 = _dbContextUyelik2;
		}

		public virtual void Migrate()
		{

		}
	}
}
