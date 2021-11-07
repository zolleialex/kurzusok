using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Kurzusok.Models;

#nullable disable

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
        public virtual DbSet<ProgrammeDetails> ProgrammeDetails { get; set; }
        public virtual DbSet<Programmes> Programmes { get; set; }
        public virtual DbSet<Semester> Semester { get; set; }
        public virtual DbSet<SubjectProgrammes> SubjectProgrammes { get; set; }
        public virtual DbSet<Subjects> Subjects { get; set; }
        public virtual DbSet<Teachers> Teachers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Hungarian_CI_AS");

            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

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

                entity.HasIndex(e => e.RoleId, "IX_AspNetUserRoles_RoleId");

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
                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<Courses>(entity =>
            {
                entity.HasKey(e => e.CourseId)
                    .HasName("PK_COURSES");

                entity.Property(e => e.CourseId).HasColumnName("course_id");

                entity.Property(e => e.Classroom)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("classroom");

                entity.Property(e => e.Comment)
                    .IsUnicode(false)
                    .HasColumnName("comment");

                entity.Property(e => e.CourseCode).HasColumnName("course_code");

                entity.Property(e => e.CourseType)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("course_type");

                entity.Property(e => e.Hours).HasColumnName("hours");

                entity.Property(e => e.Members).HasColumnName("members");

                entity.Property(e => e.NeptunOk).HasColumnName("neptun_ok");

                entity.Property(e => e.Software)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("software");

                entity.Property(e => e.SubjectId).HasColumnName("subject_id");

                entity.HasOne(e => e.Subject).WithMany(e => e.Courses).HasForeignKey(e => e.SubjectId).OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<CoursesTeachers>(entity =>
            {
                entity.HasKey(x => new { x.CourseId, x.TeacherId });

                entity.ToTable("courses_teachers");

                entity.Property(e => e.CourseId).HasColumnName("course_id");

                entity.Property(e => e.Loads).HasColumnName("loads");

                entity.Property(e => e.TeacherId).HasColumnName("teacher_id");

                entity.HasOne(e => e.Course).WithMany(e => e.TeachersLink).HasForeignKey(e => e.CourseId).OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<ProgrammeDetails>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Creadit).HasColumnName("creadit");

                entity.Property(e => e.EHours).HasColumnName("e_hours");

                entity.Property(e => e.GyHours).HasColumnName("gy_hours");

                entity.Property(e => e.LabHours).HasColumnName("lab_hours");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Obligatory).HasColumnName("obligatory");

                entity.Property(e => e.ProgrammeId).HasColumnName("programme_id");

                entity.Property(e => e.RecommendedSemester).HasColumnName("recommended_semester");

                entity.Property(e => e.SubjectCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("subject_code");

                entity.HasOne(d => d.Programme)
                    .WithMany(p => p.ProgrammeDetails)
                    .HasForeignKey(d => d.ProgrammeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProgrammeDetails_Programmes");
            });

            modelBuilder.Entity<Programmes>(entity =>
            {
                entity.HasKey(e => e.ProgrammeId)
                    .HasName("PK_SZAKOK");

                entity.Property(e => e.ProgrammeId).HasColumnName("programme_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Training)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("training");
            });

            modelBuilder.Entity<Semester>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Date)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("date");

                entity.Property(e => e.Weeks).HasColumnName("weeks");
            });

            modelBuilder.Entity<SubjectProgrammes>(entity =>
            {
                entity.HasKey(x => new { x.SubjectId, x.ProgrammeId });

                entity.ToTable("subject_programmes");

                entity.Property(e => e.Obligatory).HasColumnName("obligatory");

                entity.Property(e => e.ProgrammeId).HasColumnName("programme_id");

                entity.Property(e => e.SubjectId).HasColumnName("subject_id");

                entity.HasOne(e => e.Subject).WithMany(e => e.ProgrammesLink).HasForeignKey(e => e.SubjectId).OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Subjects>(entity =>
            {
                entity.HasKey(e => e.SubjectId)
                    .HasName("PK_SUBJECTS");

                entity.Property(e => e.SubjectId).HasColumnName("subject_id");

                entity.Property(e => e.EHours).HasColumnName("e_hours");

                entity.Property(e => e.EducationType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("education_type");

                entity.Property(e => e.GyHours).HasColumnName("gy_hours");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.SemesterId).HasColumnName("semester_id");

                entity.Property(e => e.SubjectCode)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("subject_code");

                entity.HasOne(e => e.Semester).WithMany(e => e.Subjects).HasForeignKey(e => e.SemesterId).OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Teachers>(entity =>
            {
                entity.HasKey(e => e.TeacherId)
                    .HasName("PK_TEACHERS");

                entity.Property(e => e.TeacherId).HasColumnName("teacher_id");

                entity.Property(e => e.Hoursperweek)
                    .HasColumnName("hoursperweek")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
