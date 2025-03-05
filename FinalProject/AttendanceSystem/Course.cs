using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem
{
    public class Course
    {
        public int Id { get; set; }
        public string CourseCode { get; set; }
        public string CourseTitle { get; set; }
        public int Fees { get; set; }
        public int NumberOfClass { get; set; }
        public List<CourseStudent> CourseStudents { get; set; }
        public List<CourseTeacher> CourseTeachers { get; set; }
        public List<CourseSchedule> CourseSchedules { get; set; }

        #region Add Course
        public static void AddCourse(AppDbContext context)
        {
            Console.Write("Enter Course Code: ");
            string courseCode = Console.ReadLine();

            Console.Write("Enter Course Title: ");
            string courseTitle = Console.ReadLine();

            Console.Write("Enter Fees: ");
            int fees = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Number of Classes: ");
            int numberOfClass = Convert.ToInt32(Console.ReadLine());

            Course course = new Course
            {
                CourseCode = courseCode,
                CourseTitle = courseTitle,
                Fees = fees,
                NumberOfClass = numberOfClass
            };

            context.Courses.Add(course);
            context.SaveChanges();
        }
        #endregion

        #region View Course

        public static void ViewCourse(AppDbContext context)
        {
            Console.WriteLine("\n===|| View Course ||===");
            var courses = context.Courses.ToList();
            if (courses.Count == 0)
            {
                Console.WriteLine("No Courses Found");
                return;
            }
            foreach (var course in courses)
            {
                Console.WriteLine($"Course ID: {course.Id}");
                Console.WriteLine($"Course Code: {course.CourseCode}");
                Console.WriteLine($"Course Title: {course.CourseTitle}");
                Console.WriteLine();
            }
        }

        #endregion


    }
}
