using Hudayim.Uyelik.Migrator.Data.EntityFramework.IlanBis.Models;
using Microsoft.EntityFrameworkCore;

namespace Hudayim.Uyelik.Migrator.Data.EntityFramework.IlanBis
{
	public partial class IBDBContext : DbContext
	{
		private string _constr;

		public IBDBContext(string constr)
		{
			_constr = constr;
		}
		public IBDBContext(DbContextOptions<IBDBContext> options) : base(options)
		{
		}

		public virtual DbSet<Ilceler> Ilceler { get; set; }
		public virtual DbSet<Iller> Iller { get; set; }
		public virtual DbSet<Mahalleler> Mahalleler { get; set; }
		public virtual DbSet<Ulkeler> Ulkeler { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer(_constr);
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Ilceler>(entity =>
			{
				entity.HasOne(d => d.Il)
					.WithMany(p => p.Ilceler)
					.HasForeignKey(d => d.IlId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_Ilceler_Iller");
			});

			modelBuilder.Entity<Iller>(entity =>
			{
				entity.HasIndex(e => e.UlkeId)
					.HasName("IX_Ulke_Id");

				entity.HasOne(d => d.UlkeNavigation)
					.WithMany(p => p.Iller)
					.HasForeignKey(d => d.UlkeId)
					.HasConstraintName("FK_dbo.Iller_dbo.Ulkeler_Ulke_Id");
			});

			modelBuilder.Entity<Mahalleler>(entity =>
			{
				entity.HasIndex(e => e.IlceId)
					.HasName("IX_IlceId");

				entity.HasOne(d => d.Ilce)
					.WithMany(p => p.Mahalleler)
					.HasForeignKey(d => d.IlceId)
					.HasConstraintName("FK_dbo.Mahalleler_dbo.Ilceler_IlceId");
			});
		}
	}

}
