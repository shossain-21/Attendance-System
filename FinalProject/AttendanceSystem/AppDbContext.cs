using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem
{
    public class AppDbContext : DbContext
    {
        private readonly string _connectionString;

        public AppDbContext()
        {
            _connectionString = "Server=SANZIDA\\SQLEXPRESS; Database=CSharpB19; Trusted_Connection=True; TrustServerCertificate=True;";

        }
        //Server=SANZIDA\\SQLEXPRESS; Database=CSharpB19; Trusted_Connection=True; TrustServerCertificate=True;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourseStudent>().ToTable("CourseStudents");
            modelBuilder.Entity<CourseStudent>().HasKey(x => x.Id);

            modelBuilder.Entity<CourseTeacher>().ToTable("CourseTeachers");
            modelBuilder.Entity<CourseTeacher>().HasKey(x => x.Id);

            modelBuilder.Entity<CourseSchedule>().ToTable("CourseSchedules");
            modelBuilder.Entity<CourseSchedule>().HasKey(x => x.Id);

            #region CourseStudent Many to Many Relation
            modelBuilder.Entity<CourseStudent>()
                .HasOne(x => x.Course)
                .WithMany(x => x.CourseStudents)
                .HasForeignKey(x => x.CourseId);
            modelBuilder.Entity<CourseStudent>()
                .HasOne(x => x.Student)
                .WithMany(x => x.CourseStudents)
                .HasForeignKey(x => x.StudentId);
            #endregion

            #region CourseTeacher One To Many Relation
            modelBuilder.Entity<CourseTeacher>()
                .HasOne(c => c.Teacher)
                .WithMany(t => t.CourseTeachers)
                .HasForeignKey(c => c.TeacherId);
            #endregion

            #region CourseSchedule One To Many Relation

            modelBuilder.Entity<CourseSchedule>()
                .HasOne(c => c.Course)
                .WithMany(t => t.CourseSchedules)
                .HasForeignKey(c => c.CourseId);

            #endregion

            #region TeacherAttendance Many to One Relation
            modelBuilder.Entity<TeacherAttendance>()
                .HasOne(ta => ta.CourseTeacher)
                .WithMany()
                .HasForeignKey(ta => ta.CourseTeacherId);

            modelBuilder.Entity<TeacherAttendance>()
                .HasOne(ta => ta.CourseSchedule)
                .WithMany()
                .HasForeignKey(ta => ta.CourseScheduleId);
            #endregion

            #region StudentAttendance Many to One Relation
            modelBuilder.Entity<StudentAttendance>()
                .HasOne(sa => sa.CourseStudent)
                .WithMany()
                .HasForeignKey(sa => sa.CourseStudentId);

            modelBuilder.Entity<StudentAttendance>()
                .HasOne(sa => sa.CourseSchedule)
                .WithMany()
                .HasForeignKey(sa => sa.CourseScheduleId);
            #endregion

            #region Data Seeding
            modelBuilder.Entity<Admin>()
                .HasData([
                new Admin { Id = -1, Name = "Md. Jalaluddin", UserName = "jalaluddin", Password = "Admin123#"}
                ]);
            modelBuilder.Entity<User>()
                .HasData([
                new User { Id = 2, UserId = "sanzidahossain", Password = "Admin123#", RoleId = 1}
                ]);
            modelBuilder.Entity<Role>()
                .HasData([
                new Role { Id = 1, RoleName = "Admin"},
                new Role { Id = 2, RoleName = "Teacher"},
                new Role { Id = 3, RoleName = "Student"}
                ]);
            
            #endregion


            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<StudentAttendance> StudentAttendances { get; set; }
        public DbSet<TeacherAttendance> TeacherAttendances { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
