using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace StudentCrudEF.Models;

public partial class StudentCrudContext : DbContext
{
    

    public StudentCrudContext(DbContextOptions<StudentCrudContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

   
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(entity =>
        {
            entity.ToTable("Student");

            entity.Property(e => e.StudentId).ValueGeneratedNever();
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Class)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.SubId).HasName("PK__Subject__4D9BB84A801E4093");

            entity.ToTable("Subject");

            entity.Property(e => e.SubName)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Student).WithMany(p => p.Subjects)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__Subject__Student__4E88ABD4");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
