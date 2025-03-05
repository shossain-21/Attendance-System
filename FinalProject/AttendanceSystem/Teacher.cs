using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AttendanceSystem;
using Microsoft.EntityFrameworkCore;

namespace AttendanceSystem
{
    public class Teacher
    {
        public int Id { get; set; }
        public string TeacherId { get; set; }
        public string Name { get; set; }

        public List<CourseTeacher> CourseTeachers { get; set; }

        #region Add Teacher
        public static void AddTeacher(AppDbContext context)
        {
            Console.WriteLine("\n===|| Add New Teacher ||===");

            Console.Write("Enter Teacher Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Teacher ID: ");
            string teacherId = Console.ReadLine();

            Teacher newTeacher = new Teacher
            {
                TeacherId = teacherId,
                Name = name
            };

            context.Teachers.Add(newTeacher);

            User newUser = new User
            {
                UserId = teacherId,
                Password = "Admin123#",
                RoleId = 2
            };
            
            context.Users.Add(newUser);
            context.SaveChanges();
            Console.WriteLine("Teacher added successfully!");
        }
        #endregion

        #region View Teacher

        public static void ViewTeacher(AppDbContext context)
        {
            Console.WriteLine("\n===|| View Teacher ||===");
            var teachers = context.Teachers.ToList();
            if (teachers.Count == 0)
            {
                Console.WriteLine("No Teacher Found");
                return;
            }
            foreach (var teacher in teachers)
            {
                Console.WriteLine($"Teacher ID: {teacher.TeacherId.PadRight(16)} Name: {teacher.Name.PadRight(20)}");
            }
        }

        #endregion

        #region Assign Courses to Teacher

        public static void AssignCoursesToTeachers(AppDbContext context)
        {
            Console.WriteLine("\n===|| Add New Course to Teacher ||===");
            while (true)
            {
                Console.Write("Enter Course Code: ");
                string courseCode = Console.ReadLine();
                Console.Write("Enter Teacher ID: ");
                string teacherId = Console.ReadLine();

                var course = context.Courses
                    .Include(c => c.CourseTeachers)
                    .SingleOrDefault(c => c.CourseCode == courseCode);

                var teacher = context.Teachers
                    .Include(t => t.CourseTeachers)
                    .SingleOrDefault(t => t.TeacherId == teacherId);


                if (course == null)
                {
                    Console.WriteLine("Course not found!");
                }
                else if (teacher == null)
                {
                    Console.WriteLine("Teacher not found!");
                }
                else
                {
                    if (teacher.CourseTeachers == null)
                    {
                        teacher.CourseTeachers = new List<CourseTeacher>();
                    }

                    var existingAssignment = teacher.CourseTeachers
                        .SingleOrDefault(cs => cs.CourseId == course.Id && cs.TeacherId == teacher.Id);
                    if (existingAssignment != null)
                    {
                        Console.WriteLine("Teacher is already assigned to this course.");
                        continue;
                    }

                    teacher.CourseTeachers.Add(new CourseTeacher
                    {
                        CourseId = course.Id,
                        TeacherId = teacher.Id
                    });

                    context.SaveChanges();
                    Console.WriteLine("Course Teacher added successfully!"); return;
                }
            }
        }


        #endregion

        #region View Teacher's Assigned Courses

        public static void ViewTeacherCourses(AppDbContext context)
        {
            Console.WriteLine("\n===|| View Teacher Courses ||===");
            Console.Write("Enter Teacher ID: ");
            string teacherId = Console.ReadLine();

            var teacher = context.Teachers
                .Include(s => s.CourseTeachers)
                .ThenInclude(cs => cs.Course)
                .SingleOrDefault(s => s.TeacherId == teacherId);

            if (teacher != null)
            {
                Console.WriteLine($"Teacher ID: {teacher.TeacherId.PadRight(16)} Teacher Name: {teacher.Name.PadRight(20)}\n\n");
                Console.WriteLine("Courses: ");
                Console.WriteLine(string.Join("", teacher.CourseTeachers.Select(cs => $"{cs.Course.CourseCode} - {cs.Course.CourseTitle}\n")));
                //Console.WriteLine("Enter Any Key to Go Back to The Options Terminal"); Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Teacher not found!");
            }
        }

        #endregion
    }
}
