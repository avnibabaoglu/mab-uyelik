using Abp.Zero.EntityFrameworkCore;
using Hudayim.Uyelik.Authorization.Roles;
using Hudayim.Uyelik.Authorization.Users;
using Hudayim.Uyelik.Entities;
using Hudayim.Uyelik.MultiTenancy;
using Microsoft.EntityFrameworkCore;

namespace Hudayim.Uyelik.EntityFrameworkCore
{
	public class UyelikDbContext : AbpZeroDbContext<Tenant, Role, User, UyelikDbContext>
	{
		/* Define a DbSet for each entity of the application */
		public DbSet<Kategori> Kategoriler { get; set; }
		public DbSet<Donem> Donemler { get; set; }
		public DbSet<Birim> Birimler { get; set; }
		public DbSet<Firma> Firmalar { get; set; }
		public DbSet<Kampanya> Kampanyalar { get; set; }
		public DbSet<Ulke> Ulkeler { get; set; }
		public DbSet<Il> Iller { get; set; }
		public DbSet<Ilce> Ilceler { get; set; }
		public DbSet<Mahalle> Mahalleler { get; set; }
		public DbSet<Gelir> Gelir { get; set; }
		public DbSet<GelirTuru> GelirTurleri { get; set; }
		public DbSet<Universite> Universiteler { get; set; }
		public DbSet<Fakulte> UniversiteFakulteler { get; set; }
		public DbSet<Bolum> UniversiteBolumler { get; set; }
		public DbSet<Meslek> Meslekler { get; set; }
		public DbSet<KullaniciKategorileri> KullaniciKategorileri { get; set; }

		public UyelikDbContext(DbContextOptions<UyelikDbContext> options)
			: base(options)
		{
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Kategori>().ToTable("Kategoriler");
			modelBuilder.Entity<Donem>().ToTable("Donemler");
			modelBuilder.Entity<Birim>().ToTable("Birimler");
			modelBuilder.Entity<Firma>().ToTable("Firmalar");
			modelBuilder.Entity<Kampanya>().ToTable("Kampanyalar");
			modelBuilder.Entity<Ulke>().ToTable("Ulkeler");
			modelBuilder.Entity<Il>().ToTable("Iller");
			modelBuilder.Entity<Ilce>().ToTable("Ilceler");
			modelBuilder.Entity<Mahalle>().ToTable("Mahalleler");
			modelBuilder.Entity<Gelir>().ToTable("Gelirler");
			modelBuilder.Entity<GelirTuru>().ToTable("GelirTurleri");
			modelBuilder.Entity<Universite>().ToTable("Universiteler");
			modelBuilder.Entity<Fakulte>().ToTable("UniversiteFakulteler");
			modelBuilder.Entity<Bolum>().ToTable("UniversiteBolumler");
			modelBuilder.Entity<Meslek>().ToTable("Meslekler");
			modelBuilder.Entity<KullaniciKategorileri>().ToTable("KullaniciKategorileri");
		}
	}
}
