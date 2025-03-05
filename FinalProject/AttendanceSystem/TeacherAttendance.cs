using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem
{
    public class TeacherAttendance
    {
        [Key]
        public int Id { get; set; }
        public int CourseTeacherId { get; set; }
        public CourseTeacher CourseTeacher { get; set; }
        public int CourseScheduleId { get; set; }
        public CourseSchedule CourseSchedule { get; set; }
        public bool Class1 { get; set; }
        public bool Class2 { get; set; }
        public bool Class3 { get; set; }
        public bool Class4 { get; set; }
        public bool Class5 { get; set; }
        public bool Class6 { get; set; }
        public bool Class7 { get; set; }
        public bool Class8 { get; set; }
        public bool Class9 { get; set; }
        public bool Class10 { get; set; }
        public bool Class11 { get; set; }
        public bool Class12 { get; set; }
        public bool Class13 { get; set; }
        public bool Class14 { get; set; }
        public bool Class15 { get; set; }
        public bool Class16 { get; set; }
        public bool Class17 { get; set; }
        public bool Class18 { get; set; }
        public bool Class19 { get; set; }
        public bool Class20 { get; set; }

        public static void GiveTeacherAttendance(AppDbContext context)
        {
            Console.WriteLine("\n===|| Give Teacher Attendance ||===");

            Console.Write("Enter Teacher ID: "); var teacherId = Console.ReadLine();

            Console.Write("Enter Course Code: "); var courseCode = Console.ReadLine();

            Console.WriteLine("Enter Class Date (yyyy-mm-dd):"); var classDate = DateOnly.Parse(Console.ReadLine());

            #region Validate and Retrieve Teacher ID
            var teacher = context.Teachers
                .Where(t => t.TeacherId == teacherId)
                .Select(t => t.Id)
                .SingleOrDefault();

            if (teacher == 0)
            {
                Console.WriteLine("Teacher does not exist.");
                return;
            }
            #endregion

            #region Validate and Retrieve the course ID
            var course = context.Courses
                .Where(c => c.CourseCode == courseCode)
                .Select(c => c.Id)
                .SingleOrDefault();

            if (course == 0)
            {
                Console.WriteLine("Course does not exist.");
                return;
            }
            #endregion

            #region Validate Teacher Course Enrollment
            var courseTeacher = context.Set<CourseTeacher>()
                .Where(ct => ct.TeacherId == teacher && ct.CourseId == course)
                .Select(ct => ct.Id)
                .SingleOrDefault();

            if (courseTeacher != null)
            {
                Console.WriteLine("Teacher is enrolled in the course.");
            }
            else
            {
                Console.WriteLine("Teacher is NOT enrolled in the course.");
            }
            #endregion

            #region Validate and Retrieve the Schedule ID

            var schedule = context.Schedules
                .Where(s => s.Date == classDate)
                .Select(s => s.Id)
                .SingleOrDefault();

            if (schedule == 0)
            {
                Console.WriteLine("Schedule does not exist.");
                return;
            }
            #endregion

            #region Validate and Retrieve CourseScheduleId
            var courseSchedule = context.Set<CourseSchedule>()
                .Where(cs => cs.CourseId == course && cs.ScheduleId == schedule)
                .Select(cs => new { cs.Id, cs.ClassNo })
                .SingleOrDefault();

            if (courseSchedule == null)
            {
                Console.WriteLine("No matching Course Schedule found.");
                return;
            }
            #endregion

            #region Take Teacher Attendance
            Console.Write("Attendance (P/A): "); var attendance = Console.ReadLine();
            bool isPresent;
            if (attendance == null)
            {
                Console.WriteLine("Attendance cannot be empty.");
                return;
            }
            else if (attendance.ToUpper() == "P")
            {
                isPresent = true;
            }
            else if (attendance.ToUpper() == "A")
            {
                isPresent = false;
            }
            else
            {
                Console.WriteLine("Invalid input.");
                return;
            }
            #endregion

            #region Update Database
            var teacherAttendance = new TeacherAttendance
            {
                CourseTeacherId = courseTeacher,
                CourseScheduleId = courseSchedule.Id
            };

            switch (courseSchedule.ClassNo)
            {
                case 1:
                    teacherAttendance.Class1 = isPresent;
                    break;
                case 2:
                    teacherAttendance.Class2 = isPresent;
                    break;
                case 3:
                    teacherAttendance.Class3 = isPresent;
                    break;
                case 4:
                    teacherAttendance.Class4 = isPresent;
                    break;
                case 5:
                    teacherAttendance.Class5 = isPresent;
                    break;
                case 6:
                    teacherAttendance.Class6 = isPresent;
                    break;
                case 7:
                    teacherAttendance.Class7 = isPresent;
                    break;
                case 8:
                    teacherAttendance.Class8 = isPresent;
                    break;
                case 9:
                    teacherAttendance.Class9 = isPresent;
                    break;
                case 10:
                    teacherAttendance.Class10 = isPresent;
                    break;
                case 11:
                    teacherAttendance.Class11 = isPresent;
                    break;
                case 12:
                    teacherAttendance.Class12 = isPresent;
                    break;
                case 13:
                    teacherAttendance.Class13 = isPresent;
                    break;
                case 14:
                    teacherAttendance.Class14 = isPresent;
                    break;
                case 15:
                    teacherAttendance.Class15 = isPresent;
                    break;
                case 16:
                    teacherAttendance.Class16 = isPresent;
                    break;
                case 17:
                    teacherAttendance.Class17 = isPresent;
                    break;
                case 18:
                    teacherAttendance.Class18 = isPresent;
                    break;
                case 19:
                    teacherAttendance.Class19 = isPresent;
                    break;
                case 20:
                    teacherAttendance.Class20 = isPresent;
                    break;
                default:
                    Console.WriteLine("Invalid class number.");
                    return;
            }

            context.TeacherAttendances.Add(teacherAttendance);
            context.SaveChanges();
            Console.WriteLine("Attendance recorded successfully.");

            #endregion
        }
    }
}
