using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PhyndDemo_v2.Model;

#nullable disable

namespace PhyndDemo_v2.Data
{
    public partial class phynd2Context : DbContext
    {
        public phynd2Context()
        {
        }

        public phynd2Context(DbContextOptions<phynd2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Efmigrationshistory> Efmigrationshistories { get; set; }
        public virtual DbSet<History> Histories { get; set; }
        public virtual DbSet<Hospital> Hospitals { get; set; }
        public virtual DbSet<Model.Program> Programs { get; set; }
        public virtual DbSet<Provider> Providers { get; set; }
        public virtual DbSet<Providerprogram> Providerprograms { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Userrole> Userroles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Efmigrationshistory>(entity =>
            {
                entity.HasKey(e => e.MigrationId)
                    .HasName("PRIMARY");
            });

            modelBuilder.Entity<History>(entity =>
            {
                entity.Property(e => e.ActionTime).HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<Model.Program>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.ModifiedOn).HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<Provider>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.ModifiedOn).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(d => d.Hospital)
                    .WithMany(p => p.Providers)
                    .HasForeignKey(d => d.HospitalId)
                    .HasConstraintName("provider_ibfk_1");
            });

            modelBuilder.Entity<Providerprogram>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.ModifiedOn).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(d => d.Program)
                    .WithMany(p => p.Providerprograms)
                    .HasForeignKey(d => d.ProgramId)
                    .HasConstraintName("providerprogram_ibfk_1");

                entity.HasOne(d => d.Provider)
                    .WithMany(p => p.Providerprograms)
                    .HasForeignKey(d => d.ProviderId)
                    .HasConstraintName("providerprogram_ibfk_2");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.ModifiedOn).HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<Userrole>(entity =>
            {
                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Userroles)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("userrole_ibfk_1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Userroles)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("userrole_ibfk_2");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
