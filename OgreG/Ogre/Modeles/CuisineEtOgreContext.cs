using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Ogre.Modeles
{
    public partial class CuisineEtOgreContext : DbContext
    {
        public CuisineEtOgreContext()
        {
        }

        public CuisineEtOgreContext(DbContextOptions<CuisineEtOgreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Plat> Plats { get; set; } = null!;
        public virtual DbSet<TypePlat> TypePlats { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=CuisineEtOgre;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Plat>(entity =>
            {
                entity.HasKey(e => e.PlatsId);

                entity.ToTable("Plat");

                entity.Property(e => e.PlatsId).HasColumnName("PlatsID");

                entity.Property(e => e.TaillePlatMoyen).HasColumnName("Taille_Plat_Moyen");

                entity.Property(e => e.TempsMoyenPreparationPlat).HasColumnName("Temps_Moyen_Preparation_Plat");

                entity.Property(e => e.Type).HasDefaultValueSql("(N'')");
            });

            modelBuilder.Entity<TypePlat>(entity =>
            {
                entity.Property(e => e.TypePlatId).HasColumnName("TypePlatID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
