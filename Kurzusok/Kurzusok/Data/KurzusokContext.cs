using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Kurzusok.Models;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Kurzusok.Data
{
    public partial class KurzusokContext : DbContext
    {
        public KurzusokContext()
        {
        }

        public KurzusokContext(DbContextOptions<KurzusokContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Courses> Courses { get; set; }
        public virtual DbSet<CoursesTeachers> CoursesTeachers { get; set; }
        public virtual DbSet<Programmes> Programmes { get; set; }
        public virtual DbSet<Semester> Semester { get; set; }
        public virtual DbSet<SubjectProgramme> SubjectProgramme { get; set; }
        public virtual DbSet<Subjects> Subjects { get; set; }
        public virtual DbSet<Teachers> Teachers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost;Database=Kurzusok;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<Courses>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.Classroom)
                    .HasColumnName("classroom")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Comment)
                    .HasColumnName("comment")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CourseCode)
                    .IsRequired()
                    .HasColumnName("course_code")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CourseType)
                    .IsRequired()
                    .HasColumnName("course_type")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Hours).HasColumnName("hours");

                entity.Property(e => e.Members).HasColumnName("members");

                entity.Property(e => e.NeptunOk).HasColumnName("neptun_ok");

                entity.Property(e => e.Softvware)
                    .HasColumnName("softvware")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SubjectId).HasColumnName("subject_id");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Courses_fk0");
            });

            modelBuilder.Entity<CoursesTeachers>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("courses_teachers");

                entity.Property(e => e.CoursesId).HasColumnName("courses_id");

                entity.Property(e => e.Load).HasColumnName("load");

                entity.Property(e => e.TeachersId).HasColumnName("teachers_id");

                entity.HasOne(d => d.Courses)
                    .WithMany()
                    .HasForeignKey(d => d.CoursesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("courses_teachers_fk0");

                entity.HasOne(d => d.Teachers)
                    .WithMany()
                    .HasForeignKey(d => d.TeachersId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("courses_teachers_fk1");
            });

            modelBuilder.Entity<Programmes>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.Levels)
                    .IsRequired()
                    .HasColumnName("levels")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Training)
                    .IsRequired()
                    .HasColumnName("training")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Year).HasColumnName("year");
            });

            modelBuilder.Entity<Semester>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.Date)
                    .IsRequired()
                    .HasColumnName("date")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SubjectProgramme>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("subject_programme");

                entity.Property(e => e.SubjectsId).HasColumnName("subjects_id");

                entity.Property(e => e.SzakokId).HasColumnName("szakok_id");

                entity.HasOne(d => d.Subjects)
                    .WithMany()
                    .HasForeignKey(d => d.SubjectsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("subject_szakok_fk0");

                entity.HasOne(d => d.Szakok)
                    .WithMany()
                    .HasForeignKey(d => d.SzakokId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("subject_szakok_fk1");
            });

            modelBuilder.Entity<Subjects>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.EHours).HasColumnName("e_hours");

                entity.Property(e => e.GyHours).HasColumnName("gy_hours");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SemesterId).HasColumnName("semester_id");

                entity.Property(e => e.SubjectCode)
                    .IsRequired()
                    .HasColumnName("subject_code")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Semester)
                    .WithMany(p => p.Subjects)
                    .HasForeignKey(d => d.SemesterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Subjects_fk0");
            });

            modelBuilder.Entity<Teachers>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.Hoursperweek)
                    .HasColumnName("hoursperweek")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
