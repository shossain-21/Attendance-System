using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AttendanceSystem
{
    public class Student
    {
        public int Id { get; set; }
        public string StudentId { get; set; }
        public string Name { get; set; }
        public List<CourseStudent> CourseStudents { get; set; }

        #region Add Student
        public static void AddStudent(AppDbContext context)
        {
            Console.WriteLine("\n===|| Add New Student ||===");

            Console.Write("Enter Student Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Student ID: ");
            string studentId = Console.ReadLine();

            Student newStudent = new Student
            {
                StudentId = studentId,
                Name = name
            };

            context.Students.Add(newStudent);

            User newUser = new User
            {
                UserId = studentId,
                Password = "Admin123#",
                RoleId = 3
            };
            context.Users.Add(newUser);
            context.SaveChanges();

            Console.WriteLine("Student added successfully!");
        }
        #endregion

        #region View Student
        public static void ViewStudent(AppDbContext context)
        {
            Console.WriteLine("\n===|| View Student ||===");
            var students = context.Students.ToList();

            if (students.Count == 0)
            {
                Console.WriteLine("No Student Found");
                return;
            }
            foreach (var student in students)
            {
                Console.WriteLine($"Student ID: {student.StudentId.PadRight(16)} Name: {student.Name.PadRight(20)}");
            }
        }
        #endregion

        #region Assign courses to student

        public static void AssignCoursesToStudents(AppDbContext context)
        {
            Console.WriteLine("\n===|| Add New Course to Student ||===");
            while (true)
            {
                Console.Write("Enter Course Code: ");
                string courseCode = Console.ReadLine();
                Console.Write("Enter Student ID: ");
                string studentId = Console.ReadLine();

                var course = context.Courses
                    .Include(c => c.CourseStudents)
                    .SingleOrDefault(c => c.CourseCode == courseCode);

                var student = context.Students
                    .Include(s => s.CourseStudents)
                    .SingleOrDefault(s => s.StudentId == studentId);


                if (course == null)
                {
                    Console.WriteLine("Course not found!");
                }
                else if (student == null)
                {
                    Console.WriteLine("Student not found!");
                }
                else
                {
                    if (student.CourseStudents == null)
                    {
                        student.CourseStudents = new List<CourseStudent>();
                    }

                    var existingAssignment = student.CourseStudents
                        .SingleOrDefault(cs => cs.CourseId == course.Id && cs.StudentId == student.Id);
                    if (existingAssignment != null)
                    {
                        Console.WriteLine("Student is already assigned to this course.");
                        continue;
                    }

                    student.CourseStudents.Add(new CourseStudent
                    {
                        CourseId = course.Id,
                        StudentId = student.Id
                    });

                    context.SaveChanges();
                    Console.WriteLine("Course Student added successfully!"); return;
                }
            }

            //var existingAssignment = student.CourseStudents
            //    .SingleOrDefault(cs => cs.CourseId == course.Id && cs.StudentId == student.Id);
            //if (existingAssignment != null)
            //{
            //    Console.WriteLine("Student is already assigned to this course.");
            //    return;
            //}            

            //CourseStudent newCourseStudent = new CourseStudent
            //{
            //    CourseId = course.Id,
            //    StudentId = student.Id
            //};

            //context.CourseStudents.Add(newCourseStudent);

        }

        #endregion

        #region View Course Students

        public static void ViewCourseStudents(AppDbContext context)
        {
            Console.WriteLine("\n===|| View Course Students ||===");
            Console.Write("Enter Course Code: ");
            string courseCode = Console.ReadLine();

            var course = context.Courses
                .Include(c => c.CourseStudents)
                .ThenInclude(cs => cs.Student)
                .SingleOrDefault(c => c.CourseCode == courseCode);

            if (course != null)
            {
                Console.WriteLine($"Course Code: {course.CourseCode.PadRight(20)} Course Title: {course.CourseTitle.PadRight(20)}\n\n");
                Console.WriteLine("Students: ");
                Console.WriteLine(string.Join("", course.CourseStudents.Select(cs => $"{cs.Student.StudentId} - {cs.Student.Name}\n")));                
            }
            else
            {
                Console.WriteLine("Course not found!");
            }
        }


        #endregion

        #region View Student Courses

        public static void ViewStudentCourses(AppDbContext context)
        {
            Console.WriteLine("\n===|| View Student Courses ||===");
            Console.Write("Enter Student ID: ");
            string studentId = Console.ReadLine();

            var student = context.Students
                .Include(s => s.CourseStudents)
                .ThenInclude(cs => cs.Course)
                .SingleOrDefault(s => s.StudentId == studentId);

            if (student != null)
            {
                Console.WriteLine($"Student ID: {student.StudentId.PadRight(20)} Student Name: {student.Name.PadRight(20)}\n\n");
                Console.WriteLine("Courses: ");
                Console.WriteLine(string.Join("", student.CourseStudents.Select(cs => $"{cs.Course.CourseCode} - {cs.Course.CourseTitle}\n")));
            }
            else
            {
                Console.WriteLine("Student not found!");
            }
        }

        #endregion
    }
}
