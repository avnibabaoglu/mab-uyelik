using Hudayim.Uyelik.Migrator.Data.EntityFramework.Uyelik.Models;
using Microsoft.EntityFrameworkCore;

namespace Hudayim.Uyelik.Migrator.Data.EntityFramework.Uyelik
{
	public partial class UyelikDBContext : DbContext
	{
		private string _constr;

		public UyelikDBContext(string constr)
		{
			_constr = constr;
		}
		public UyelikDBContext(DbContextOptions<UyelikDBContext> options) : base(options)
		{
		}

		public virtual DbSet<HudayimUyeListesiExcel> HudayimUyeListesiExcel { get; set; }
		public virtual DbSet<AbpUsers> AbpUsers { get; set; }
		public virtual DbSet<AbpUserRoles> AbpUserRoles { get; set; }
		public virtual DbSet<AbpUserAccounts> AbpUserAccounts { get; set; }
		public virtual DbSet<MesleklerListesi> MesleklerListesi { get; set; }
		public virtual DbSet<UniversitelerListesi> UniversitelerListesi { get; set; }
		public virtual DbSet<FakultelerListesi> FakultelerListesi { get; set; }
		public virtual DbSet<BolumlerListesi> BolumlerListesi { get; set; }
		public virtual DbSet<UlkelerListesiExcel> UlkelerListesiExcel { get; set; }


		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer(_constr);
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
		}
	}

}
