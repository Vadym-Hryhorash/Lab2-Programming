using System;
using System.Collections.Generic;
using Lab2_Programming.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab2_Programming.Data;

public partial class SchoolDbContext : DbContext
{
    public SchoolDbContext()
    {

    }

    public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options)
    {

    }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5433;Database=school;Username=postgres;Password=postgre");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("student_pkey");

            entity.ToTable("student");

            entity.Property(e => e.StudentId).HasColumnName("student_id");
            entity.Property(e => e.AvarageGrade).HasColumnName("avarage_grade");
            entity.Property(e => e.LastName)
                .HasMaxLength(30)
                .HasColumnName("last_name");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnName("name");
            entity.Property(e => e.ParentsPhone)
                .HasMaxLength(13)
                .HasColumnName("parents_phone");
            entity.Property(e => e.TeacherId).HasColumnName("teacher_id");
            entity.Property(e => e.ThirdName)
                .HasMaxLength(30)
                .HasColumnName("third_name");

            entity.HasOne(d => d.Teacher).WithMany(p => p.Students)
                .HasForeignKey(d => d.TeacherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("student_teacher_id_fkey");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.TeacherId).HasName("teacher_pkey");

            entity.ToTable("teacher");

            entity.Property(e => e.TeacherId).HasColumnName("teacher_id");
            entity.Property(e => e.LastName)
                .HasMaxLength(30)
                .HasColumnName("last_name");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnName("name");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(13)
                .HasColumnName("phone_number");
            entity.Property(e => e.Salary).HasColumnName("salary");
            entity.Property(e => e.TeacherClass)
                .HasMaxLength(5)
                .HasColumnName("teacher_class");
            entity.Property(e => e.ThirdName)
                .HasMaxLength(30)
                .HasColumnName("third_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
