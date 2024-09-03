using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace jwt_token_auth.anotherAPI.Models
{
    public partial class filedetailsContext : DbContext
    {
        public filedetailsContext()
        {
        }

        public filedetailsContext(DbContextOptions<filedetailsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DocumentAttachment> DocumentAttachments { get; set; } = null!;
        public virtual DbSet<LoginModel> LoginModels { get; set; } = null!;
        public virtual DbSet<RegisterModel> RegisterModels { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-KT4P7N2U\\MSSQLSERVER01; Database=filedetails; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DocumentAttachment>(entity =>
            {
                entity.ToTable("DocumentAttachment");
            });

            modelBuilder.Entity<LoginModel>(entity =>
            {
                entity.ToTable("LoginModel");

                entity.Property(e => e.PasswordHash).HasMaxLength(100);

                entity.Property(e => e.Username).HasMaxLength(100);
            });

            modelBuilder.Entity<RegisterModel>(entity =>
            {
                entity.ToTable("RegisterModel");

                entity.Property(e => e.PasswordHash).HasMaxLength(100);

                entity.Property(e => e.Username).HasMaxLength(100);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Username).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
