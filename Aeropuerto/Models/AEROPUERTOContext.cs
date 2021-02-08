using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Aeropuerto.models
{
    public partial class AEROPUERTOContext : DbContext
    {
        public AEROPUERTOContext()
        {
        }

        public AEROPUERTOContext(DbContextOptions<AEROPUERTOContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Aviones> Aviones { get; set; }
        public virtual DbSet<Hangares> Hangares { get; set; }
        public virtual DbSet<LineaAerea> LineaAerea { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("server=DESKTOP-EI5R9TL; database=AEROPUERTO; trusted_connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aviones>(entity =>
            {
                entity.ToTable("AVIONES");

                entity.Property(e => e.IdLinea).HasColumnName("id_Linea");

                entity.Property(e => e.Modelo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Tamano)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdLineaNavigation)
                    .WithMany(p => p.Aviones)
                    .HasForeignKey(d => d.IdLinea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AVIONES__id_Line__1273C1CD");
            });

            modelBuilder.Entity<Hangares>(entity =>
            {
                entity.ToTable("HANGARES");

                entity.Property(e => e.CostoRenta)
                    .HasColumnName("Costo_Renta")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LineaAerea>(entity =>
            {
                entity.ToTable("LINEA_AEREA");

                entity.Property(e => e.FechaInicio)
                    .HasColumnName("Fecha_inicio")
                    .HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
