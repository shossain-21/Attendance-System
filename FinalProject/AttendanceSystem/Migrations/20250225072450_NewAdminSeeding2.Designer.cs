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
    [Migration("20250225072450_NewAdminSeeding2")]
    partial class NewAdminSeeding2
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

            modelBuilder.Entity("AttendanceSystem.Attendance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Attendances");
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

            modelBuilder.Entity("AttendanceSystem.CourseStudent", b =>
                {
                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("CourseId", "StudentId");

                    b.HasIndex("StudentId");

                    b.ToTable("CourseStudents", (string)null);
                });

            modelBuilder.Entity("AttendanceSystem.CourseTeacher", b =>
                {
                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("CourseId", "TeacherId");

                    b.HasIndex("TeacherId");

                    b.ToTable("CourseTeachers", (string)null);
                });

            modelBuilder.Entity("AttendanceSystem.Day", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DayOfWeek")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Days");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DayOfWeek = "Saturday"
                        },
                        new
                        {
                            Id = 2,
                            DayOfWeek = "Sunday"
                        },
                        new
                        {
                            Id = 3,
                            DayOfWeek = "Monday"
                        },
                        new
                        {
                            Id = 4,
                            DayOfWeek = "Tuesday"
                        },
                        new
                        {
                            Id = 5,
                            DayOfWeek = "Wednesday"
                        },
                        new
                        {
                            Id = 6,
                            DayOfWeek = "Thursday"
                        });
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

                    b.Property<TimeOnly>("ClassEndTime")
                        .HasColumnType("time");

                    b.Property<TimeOnly>("ClassStartTime")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.ToTable("Schedules");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ClassEndTime = new TimeOnly(9, 10, 0),
                            ClassStartTime = new TimeOnly(8, 20, 0)
                        },
                        new
                        {
                            Id = 2,
                            ClassEndTime = new TimeOnly(10, 0, 0),
                            ClassStartTime = new TimeOnly(9, 11, 0)
                        },
                        new
                        {
                            Id = 3,
                            ClassEndTime = new TimeOnly(10, 50, 0),
                            ClassStartTime = new TimeOnly(10, 1, 0)
                        },
                        new
                        {
                            Id = 4,
                            ClassEndTime = new TimeOnly(11, 40, 0),
                            ClassStartTime = new TimeOnly(10, 51, 0)
                        },
                        new
                        {
                            Id = 5,
                            ClassEndTime = new TimeOnly(12, 30, 0),
                            ClassStartTime = new TimeOnly(11, 41, 0)
                        },
                        new
                        {
                            Id = 6,
                            ClassEndTime = new TimeOnly(13, 20, 0),
                            ClassStartTime = new TimeOnly(12, 31, 0)
                        });
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
                        },
                        new
                        {
                            Id = 8,
                            Password = "1",
                            RoleId = 1,
                            UserId = "1"
                        });
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

            modelBuilder.Entity("AttendanceSystem.Course", b =>
                {
                    b.Navigation("CourseStudents");

                    b.Navigation("CourseTeachers");
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
