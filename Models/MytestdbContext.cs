using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SampleWebApi.Models;

public partial class MytestdbContext : DbContext
{
    public MytestdbContext()
    {
    }

    public MytestdbContext(DbContextOptions<MytestdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Clients1> Clients1s { get; set; }

    public virtual DbSet<Clientss> Clientsses { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=MYTESTDB;User ID=sa;password=Welcome@#123;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__clients__3213E83FA989DB0E");

            entity.ToTable("clients");

            entity.HasIndex(e => e.Email, "UQ__clients__AB6E6164CB71598B").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phone");
        });

        modelBuilder.Entity<Clients1>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__clients1__3213E83FB3A173C1");

            entity.ToTable("clients1");

            entity.HasIndex(e => e.Email, "UQ__clients1__AB6E616411568623").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phone");
        });

        modelBuilder.Entity<Clientss>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__clientss__3213E83F3D3777DD");

            entity.ToTable("clientss");

            entity.HasIndex(e => e.Email, "UQ__clientss__AB6E6164A6FB093E").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phone");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Department");

            entity.Property(e => e.DepartmentId).ValueGeneratedOnAdd();
            entity.Property(e => e.DepartmentName).HasMaxLength(500);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
			entity.HasKey(e => new { e.EmployeeId })
				 .HasName("PK__UserDeta__6F9E65E3D0D59B88");

			entity.Property(e => e.DateOfJoining).HasColumnType("datetime");
            entity.Property(e => e.Department).HasMaxLength(500);
            entity.Property(e => e.EmployeeId).ValueGeneratedOnAdd();
            entity.Property(e => e.EmployeeName).HasMaxLength(500);
            entity.Property(e => e.PhotoFileName).HasMaxLength(500);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
