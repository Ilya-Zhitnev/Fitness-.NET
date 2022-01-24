using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace FitnessClubLibrary.Models
{
    public partial class FitnessClubContext : DbContext
    {
        public FitnessClubContext()
        {
        }

        public FitnessClubContext(DbContextOptions<FitnessClubContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Coach> Coaches { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=HOUSEMINI\\APELSINSERVER;Initial Catalog=FitnessClub;Persist Security Info=False;User ID=sa;Password=9473517;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("Client");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Fio)
                    .HasMaxLength(100)
                    .HasColumnName("FIO");

                entity.Property(e => e.Phone).HasMaxLength(13);

                entity.HasOne(d => d.CoachNavigation)
                    .WithMany(p => p.Clients)
                    .HasForeignKey(d => d.Coach)
                    .HasConstraintName("FK_Client_Coach");
            });

            modelBuilder.Entity<Coach>(entity =>
            {
                entity.ToTable("Coach");

                entity.Property(e => e.Fio)
                    .HasMaxLength(100)
                    .HasColumnName("FIO");

                entity.Property(e => e.Phone).HasMaxLength(13);

                entity.Property(e => e.Rank).HasMaxLength(50);

                entity.Property(e => e.WorkLevel).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
