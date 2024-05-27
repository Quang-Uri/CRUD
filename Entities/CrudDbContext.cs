using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Web_CRUD.Entities
{
    public partial class CrudDbContext : DbContext
    {
        public CrudDbContext()
        {
        }

        public CrudDbContext(DbContextOptions<CrudDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Huyen> Huyens { get; set; }
        public virtual DbSet<Tinh> Tinhs { get; set; }
        public virtual DbSet<Xa> Xas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Huyen>(entity =>
            {
                entity.HasKey(e => e.IdHuyen).HasName("PK__Huyen__A189AEEB59DBC258");

                entity.ToTable("Huyen");

                entity.Property(e => e.Cap).HasMaxLength(50);
                entity.Property(e => e.Ten).HasMaxLength(100);

                entity.HasOne(d => d.IdTinhNavigation).WithMany(p => p.Huyens)
                    .HasForeignKey(d => d.IdTinh)
                    .OnDelete(DeleteBehavior.Cascade) // Thay đổi thành DeleteBehavior.Cascade
                    .HasConstraintName("FK__Huyen__IdTinh__398D8EEE");
            });

            modelBuilder.Entity<Tinh>(entity =>
            {
                entity.HasKey(e => e.IdTinh).HasName("PK__Tinh__9E3A39EC645ED5B7");

                entity.ToTable("Tinh");

                entity.Property(e => e.Cap).HasMaxLength(50);
                entity.Property(e => e.Ten).HasMaxLength(100);
            });

            modelBuilder.Entity<Xa>(entity =>
            {
                entity.HasKey(e => e.IdXa).HasName("PK__Xa__B7707C56338AA992");

                entity.ToTable("Xa");

                entity.Property(e => e.Cap).HasMaxLength(50);
                entity.Property(e => e.Ten).HasMaxLength(100);

                entity.HasOne(d => d.IdHuyenNavigation).WithMany(p => p.Xas)
                    .HasForeignKey(d => d.IdHuyen)
                    .OnDelete(DeleteBehavior.Cascade) // Thay đổi thành DeleteBehavior.Cascade
                    .HasConstraintName("FK__Xa__IdHuyen__3C69FB99");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
