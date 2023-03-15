using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Student_Mngement_system.Entities;

public partial class EmployeeDBContext : DbContext
{
    public EmployeeDBContext()
    {
    }

    public EmployeeDBContext(DbContextOptions<EmployeeDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Employee2> Employee2s { get; set; }

    public virtual DbSet<EmplyeeDetail> EmplyeeDetails { get; set; }

  

    public virtual DbSet<StudentMangement> StudentMangements { get; set; }


   

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=192.168.2.30;Database= Testing_DikshaDahiya;User ID=DikshaDahiya;Password=WawX6UCZx3rcPubR;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Employee");

            entity.Property(e => e.EmailAddress).HasMaxLength(500);
            entity.Property(e => e.EmployeeName).HasMaxLength(500);
            entity.Property(e => e.MobileNo).HasMaxLength(500);
        });

        modelBuilder.Entity<Employee2>(entity =>
        {
            entity.ToTable("Employee2");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Age)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.ContactNo)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Firstname).HasMaxLength(50);
            entity.Property(e => e.Lastname).HasMaxLength(50);
        });

        modelBuilder.Entity<EmplyeeDetail>(entity =>
        {
            entity.ToTable("EmplyeeDetail");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Designation)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsFixedLength();
        });

       

        modelBuilder.Entity<StudentMangement>(entity =>
        {
            entity.ToTable("StudentMangement");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address).HasMaxLength(100);
            entity.Property(e => e.Descriptions).HasMaxLength(100);
            entity.Property(e => e.Dob).HasMaxLength(100);
            entity.Property(e => e.Documents).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Grade).HasMaxLength(100);
            entity.Property(e => e.Image).HasMaxLength(100);
            entity.Property(e => e.Mobile).HasMaxLength(100);
            entity.Property(e => e.Studentname).HasMaxLength(100);
        });

       

      
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
