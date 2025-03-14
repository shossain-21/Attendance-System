﻿// <auto-generated />
using System;
using AttendanceSystem;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AttendanceSystem.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250228073124_AddForeignKeyOfCourseStudentInStudentAttendance")]
    partial class AddForeignKeyOfCourseStudentInStudentAttendance
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AttendanceSystem.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Admins");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            Name = "Md. Jalaluddin",
                            Password = "Admin123#",
                            UserName = "jalaluddin"
                        });
                });

            modelBuilder.Entity("AttendanceSystem.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CourseCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CourseTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Fees")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfClass")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("AttendanceSystem.CourseSchedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClassNo")
                        .HasColumnType("int");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("ScheduleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("ScheduleId");

                    b.ToTable("CourseSchedules", (string)null);
                });

            modelBuilder.Entity("AttendanceSystem.CourseStudent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("StudentId");

                    b.ToTable("CourseStudents", (string)null);
                });

            modelBuilder.Entity("AttendanceSystem.CourseTeacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("TeacherId");

                    b.ToTable("CourseTeachers", (string)null);
                });

            modelBuilder.Entity("AttendanceSystem.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            RoleName = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            RoleName = "Teacher"
                        },
                        new
                        {
                            Id = 3,
                            RoleName = "Student"
                        });
                });

            modelBuilder.Entity("AttendanceSystem.Schedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("AttendanceSystem.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudentId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("AttendanceSystem.StudentAttendance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Class1")
                        .HasColumnType("bit");

                    b.Property<bool>("Class10")
                        .HasColumnType("bit");

                    b.Property<bool>("Class11")
                        .HasColumnType("bit");

                    b.Property<bool>("Class12")
                        .HasColumnType("bit");

                    b.Property<bool>("Class13")
                        .HasColumnType("bit");

                    b.Property<bool>("Class14")
                        .HasColumnType("bit");

                    b.Property<bool>("Class15")
                        .HasColumnType("bit");

                    b.Property<bool>("Class16")
                        .HasColumnType("bit");

                    b.Property<bool>("Class17")
                        .HasColumnType("bit");

                    b.Property<bool>("Class18")
                        .HasColumnType("bit");

                    b.Property<bool>("Class19")
                        .HasColumnType("bit");

                    b.Property<bool>("Class2")
                        .HasColumnType("bit");

                    b.Property<bool>("Class20")
                        .HasColumnType("bit");

                    b.Property<bool>("Class3")
                        .HasColumnType("bit");

                    b.Property<bool>("Class4")
                        .HasColumnType("bit");

                    b.Property<bool>("Class5")
                        .HasColumnType("bit");

                    b.Property<bool>("Class6")
                        .HasColumnType("bit");

                    b.Property<bool>("Class7")
                        .HasColumnType("bit");

                    b.Property<bool>("Class8")
                        .HasColumnType("bit");

                    b.Property<bool>("Class9")
                        .HasColumnType("bit");

                    b.Property<int>("CourseScheduleId")
                        .HasColumnType("int");

                    b.Property<int>("CourseStudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CourseScheduleId");

                    b.HasIndex("CourseStudentId");

                    b.ToTable("StudentAttendances");
                });

            modelBuilder.Entity("AttendanceSystem.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TeacherId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("AttendanceSystem.TeacherAttendance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Class1")
                        .HasColumnType("bit");

                    b.Property<bool>("Class10")
                        .HasColumnType("bit");

                    b.Property<bool>("Class11")
                        .HasColumnType("bit");

                    b.Property<bool>("Class12")
                        .HasColumnType("bit");

                    b.Property<bool>("Class13")
                        .HasColumnType("bit");

                    b.Property<bool>("Class14")
                        .HasColumnType("bit");

                    b.Property<bool>("Class15")
                        .HasColumnType("bit");

                    b.Property<bool>("Class16")
                        .HasColumnType("bit");

                    b.Property<bool>("Class17")
                        .HasColumnType("bit");

                    b.Property<bool>("Class18")
                        .HasColumnType("bit");

                    b.Property<bool>("Class19")
                        .HasColumnType("bit");

                    b.Property<bool>("Class2")
                        .HasColumnType("bit");

                    b.Property<bool>("Class20")
                        .HasColumnType("bit");

                    b.Property<bool>("Class3")
                        .HasColumnType("bit");

                    b.Property<bool>("Class4")
                        .HasColumnType("bit");

                    b.Property<bool>("Class5")
                        .HasColumnType("bit");

                    b.Property<bool>("Class6")
                        .HasColumnType("bit");

                    b.Property<bool>("Class7")
                        .HasColumnType("bit");

                    b.Property<bool>("Class8")
                        .HasColumnType("bit");

                    b.Property<bool>("Class9")
                        .HasColumnType("bit");

                    b.Property<int>("CourseScheduleId")
                        .HasColumnType("int");

                    b.Property<int>("CourseTeacherId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CourseScheduleId");

                    b.HasIndex("CourseTeacherId");

                    b.ToTable("TeacherAttendances");
                });

            modelBuilder.Entity("AttendanceSystem.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            Password = "Admin123#",
                            RoleId = 1,
                            UserId = "sanzidahossain"
                        });
                });

            modelBuilder.Entity("AttendanceSystem.CourseSchedule", b =>
                {
                    b.HasOne("AttendanceSystem.Course", "Course")
                        .WithMany("CourseSchedules")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AttendanceSystem.Schedule", "Schedule")
                        .WithMany("CourseSchedules")
                        .HasForeignKey("ScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Schedule");
                });

            modelBuilder.Entity("AttendanceSystem.CourseStudent", b =>
                {
                    b.HasOne("AttendanceSystem.Course", "Course")
                        .WithMany("CourseStudents")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AttendanceSystem.Student", "Student")
                        .WithMany("CourseStudents")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("AttendanceSystem.CourseTeacher", b =>
                {
                    b.HasOne("AttendanceSystem.Course", "Course")
                        .WithMany("CourseTeachers")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AttendanceSystem.Teacher", "Teacher")
                        .WithMany("CourseTeachers")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("AttendanceSystem.StudentAttendance", b =>
                {
                    b.HasOne("AttendanceSystem.CourseSchedule", "CourseSchedule")
                        .WithMany()
                        .HasForeignKey("CourseScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AttendanceSystem.CourseStudent", "CourseStudent")
                        .WithMany()
                        .HasForeignKey("CourseStudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CourseSchedule");

                    b.Navigation("CourseStudent");
                });

            modelBuilder.Entity("AttendanceSystem.TeacherAttendance", b =>
                {
                    b.HasOne("AttendanceSystem.CourseSchedule", "CourseSchedule")
                        .WithMany()
                        .HasForeignKey("CourseScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AttendanceSystem.CourseTeacher", "CourseTeacher")
                        .WithMany()
                        .HasForeignKey("CourseTeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CourseSchedule");

                    b.Navigation("CourseTeacher");
                });

            modelBuilder.Entity("AttendanceSystem.Course", b =>
                {
                    b.Navigation("CourseSchedules");

                    b.Navigation("CourseStudents");

                    b.Navigation("CourseTeachers");
                });

            modelBuilder.Entity("AttendanceSystem.Schedule", b =>
                {
                    b.Navigation("CourseSchedules");
                });

            modelBuilder.Entity("AttendanceSystem.Student", b =>
                {
                    b.Navigation("CourseStudents");
                });

            modelBuilder.Entity("AttendanceSystem.Teacher", b =>
                {
                    b.Navigation("CourseTeachers");
                });
#pragma warning restore 612, 618
        }
    }
}
