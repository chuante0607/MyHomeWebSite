using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MyHomeWebSite.Models
{
    public partial class MyDBContext : DbContext
    {
        public MyDBContext()
        {
        }

        public MyDBContext(DbContextOptions<MyDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Adatum> Adata { get; set; } = null!;
        public virtual DbSet<Aemployee> Aemployees { get; set; } = null!;
        public virtual DbSet<Attendance> Attendances { get; set; } = null!;
        public virtual DbSet<Branch> Branches { get; set; } = null!;
        public virtual DbSet<Class> Classes { get; set; } = null!;
        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Family> Families { get; set; } = null!;
        public virtual DbSet<Holiday> Holidays { get; set; } = null!;
        public virtual DbSet<HolidayDetail> HolidayDetails { get; set; } = null!;
        public virtual DbSet<OverTimeDetail> OverTimeDetails { get; set; } = null!;
        public virtual DbSet<Plan> Plans { get; set; } = null!;
        public virtual DbSet<Score> Scores { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<Sub> Subs { get; set; } = null!;
        public virtual DbSet<Teacher> Teachers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=.\\sqlexpress;Database=MyDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Adatum>(entity =>
            {
                entity.ToTable("AData");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Account)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PassWord)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("UserID");
            });

            modelBuilder.Entity<Aemployee>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("AEmployee");

                entity.Property(e => e.UserId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("UserID");

                entity.Property(e => e.Birthday).HasColumnType("date");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.SupervisorId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("SupervisorID");

                entity.Property(e => e.Unit).HasMaxLength(100);
            });

            modelBuilder.Entity<Attendance>(entity =>
            {
                entity.ToTable("Attendance");

                entity.Property(e => e.Shift).HasMaxLength(50);

                entity.Property(e => e.WorkDate).HasColumnType("date");
            });

            modelBuilder.Entity<Branch>(entity =>
            {
                entity.ToTable("Branch");

                entity.Property(e => e.Head).HasMaxLength(50);

                entity.Property(e => e.Title).HasMaxLength(50);

                entity.HasOne(d => d.HeadNavigation)
                    .WithMany(p => p.Branches)
                    .HasForeignKey(d => d.Head)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Branch_Employees");
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.ToTable("Class");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ClassName).HasMaxLength(50);
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(e => e.CId)
                    .HasName("PK__Course__213EE77426EF90D8");

                entity.ToTable("Course");

                entity.Property(e => e.CId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("c_id");

                entity.Property(e => e.CName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("c_name")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("t_id");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.Eid);

                entity.Property(e => e.Eid)
                    .HasMaxLength(50)
                    .HasColumnName("EId")
                    .HasComment("工號");

                entity.Property(e => e.Branch).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.EnglishName).HasMaxLength(50);

                entity.Property(e => e.Image).HasMaxLength(50);

                entity.Property(e => e.JobTitle).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasComment("姓名");

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.Property(e => e.Sex).HasMaxLength(10);

                entity.Property(e => e.Shift).HasMaxLength(50);

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.BranchNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.BranchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employees_Branch");
            });

            modelBuilder.Entity<Family>(entity =>
            {
                entity.ToTable("family");

                entity.Property(e => e.ChildName).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Holiday>(entity =>
            {
                entity.HasKey(e => e.Hid)
                    .HasName("PK_Leave");

                entity.Property(e => e.Hid).HasColumnName("HId");

                entity.Property(e => e.Title).HasMaxLength(50);
            });

            modelBuilder.Entity<HolidayDetail>(entity =>
            {
                entity.Property(e => e.AllowManager).HasMaxLength(50);

                entity.Property(e => e.ApplyDate).HasColumnType("date");

                entity.Property(e => e.BeginDate).HasColumnType("date");

                entity.Property(e => e.Eid)
                    .HasMaxLength(50)
                    .HasColumnName("EId");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.Hid).HasColumnName("HId");

                entity.HasOne(d => d.EidNavigation)
                    .WithMany(p => p.HolidayDetails)
                    .HasForeignKey(d => d.Eid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HolidayDetails_Employees");

                entity.HasOne(d => d.HidNavigation)
                    .WithMany(p => p.HolidayDetails)
                    .HasForeignKey(d => d.Hid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HolidayDetails_Holidays");
            });

            modelBuilder.Entity<OverTimeDetail>(entity =>
            {
                entity.Property(e => e.Eid)
                    .HasMaxLength(50)
                    .HasColumnName("EId");

                entity.Property(e => e.OverTimeDate).HasColumnType("date");

                entity.HasOne(d => d.EidNavigation)
                    .WithMany(p => p.OverTimeDetails)
                    .HasForeignKey(d => d.Eid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OverTimeDetails_Employees");
            });

            modelBuilder.Entity<Plan>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.PlanTitle).HasMaxLength(50);

                entity.Property(e => e.StartDate).HasColumnType("date");
            });

            modelBuilder.Entity<Score>(entity =>
            {
                entity.HasKey(e => new { e.SId, e.CId })
                    .HasName("PK__Score__7D256A830EDD0472");

                entity.ToTable("Score");

                entity.Property(e => e.SId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("s_id");

                entity.Property(e => e.CId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("c_id");

                entity.Property(e => e.SScore).HasColumnName("s_score");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.SId)
                    .HasName("PK__Student__2F3684F47C45494A");

                entity.ToTable("Student");

                entity.Property(e => e.SId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("s_id");

                entity.Property(e => e.SBirth)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("s_birth")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("s_name")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SSex)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("s_sex")
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<Sub>(entity =>
            {
                entity.ToTable("Sub");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.StudentId).HasColumnName("Student_ID");

                entity.Property(e => e.SubJect).HasMaxLength(50);
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.HasKey(e => e.TId)
                    .HasName("PK__Teacher__E579775F2AFF2CDE");

                entity.ToTable("Teacher");

                entity.Property(e => e.TId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("t_id");

                entity.Property(e => e.TName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("t_name")
                    .HasDefaultValueSql("('')");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
