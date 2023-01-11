using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SampleWebApi.Models;

public partial class StuffKartContext : DbContext
{
    public StuffKartContext()
    {
    }

    public StuffKartContext(DbContextOptions<StuffKartContext> options)
        : base(options)
    {
    }

    public virtual DbSet<UserDetail> UserDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=StuffKart;User ID=sa;password=Welcome@#123;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserDetail>(entity =>
        {
			entity.HasKey(e => new { e.UserId })
				 .HasName("PK__UserDeta__6F9E65E3D0D59B88");


			entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IsAdmin).HasColumnName("isAdmin");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SecurityAnswer).HasMaxLength(100);
            entity.Property(e => e.SecurityQuestion).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
