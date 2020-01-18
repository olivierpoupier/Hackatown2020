using System;
using Microsoft.EntityFrameworkCore;
using Hackatown2020.Models;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Hackatown2020.Context
{
    public partial class Hackatown2020Context : DbContext
    {
        public Hackatown2020Context()
        {
        }

        public Hackatown2020Context(DbContextOptions<Hackatown2020Context> options)
            : base(options)
        {
        }

        public virtual DbSet<CoordonneesStationsRsqa> CoordonneesStationsRsqa { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=OPOUP-MACOS;Database=Hackatown2020;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CoordonneesStationsRsqa>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("coordonnees-stations-rsqa");

                entity.Property(e => e.Adresse)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ArrondissementVille)
                    .HasColumnName("Arrondissement Ville")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Latitude)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Longitude)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nom)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroStation)
                    .HasColumnName("Numero station")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
