using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace AttendanceSystem
{
    public class StudentAttendance
    {
        [Key]
        public int Id { get; set; }
        public int CourseStudentId { get; set; }
        public CourseStudent CourseStudent { get; set; }
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

        #region Give Student Attendance
        public static void GiveStudentAttendance(AppDbContext context)
        {
            Console.WriteLine("\n===|| Give Student Attendance ||===");

            Console.Write("Enter Student ID: "); var studentId = Console.ReadLine();

            Console.Write("Enter Course Code: "); var courseCode = Console.ReadLine();

            Console.Write("Enter Class Date (yyyy-mm-dd):"); var classDate = DateOnly.Parse(Console.ReadLine());

            #region Validate and Retrieve Student ID
            var student = context.Students
                .Where(s => s.StudentId == studentId)
                .Select(s => s.Id)
                .SingleOrDefault();

            if (student == 0)
            {
                Console.WriteLine("Student does not exist.");
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

            #region Validate Student Course Enrollment
            var courseStudent = context.Set<CourseStudent>()
                .Where(cs => cs.StudentId == student && cs.CourseId == course)
                .Select(cs => cs.Id)
                .SingleOrDefault();

            if (courseStudent != null)
            {
                Console.WriteLine("Student is enrolled in the course.");
            }
            else
            {
                Console.WriteLine("Student is NOT enrolled in the course.");
            }
            #endregion

            #region Validate and Retrieve the Schedule ID

            var schedule = context.Schedules
                .Where(s => s.Date == classDate)
                .Select(s => s.Id)
                .FirstOrDefault();

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

            #region Take Student Attendance
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
            var studentAttendance = new StudentAttendance
            {
                CourseStudentId = courseStudent,
                CourseScheduleId = courseSchedule.Id
            };

            switch (courseSchedule.ClassNo)
            {
                case 1:
                    studentAttendance.Class1 = isPresent;
                    break;
                case 2:
                    studentAttendance.Class2 = isPresent;
                    break;
                case 3:
                    studentAttendance.Class3 = isPresent;
                    break;
                case 4:
                    studentAttendance.Class4 = isPresent;
                    break;
                case 5:
                    studentAttendance.Class5 = isPresent;
                    break;
                case 6:
                    studentAttendance.Class6 = isPresent;
                    break;
                case 7:
                    studentAttendance.Class7 = isPresent;
                    break;
                case 8:
                    studentAttendance.Class8 = isPresent;
                    break;
                case 9:
                    studentAttendance.Class9 = isPresent;
                    break;
                case 10:
                    studentAttendance.Class10 = isPresent;
                    break;
                case 11:
                    studentAttendance.Class11 = isPresent;
                    break;
                case 12:
                    studentAttendance.Class12 = isPresent;
                    break;
                case 13:
                    studentAttendance.Class13 = isPresent;
                    break;
                case 14:
                    studentAttendance.Class14 = isPresent;
                    break;
                case 15:
                    studentAttendance.Class15 = isPresent;
                    break;
                case 16:
                    studentAttendance.Class16 = isPresent;
                    break;
                case 17:
                    studentAttendance.Class17 = isPresent;
                    break;
                case 18:
                    studentAttendance.Class18 = isPresent;
                    break;
                case 19:
                    studentAttendance.Class19 = isPresent;
                    break;
                case 20:
                    studentAttendance.Class20 = isPresent;
                    break;
                default:
                    Console.WriteLine("Invalid class number.");
                    return;
            }

            context.StudentAttendances.Add(studentAttendance);
            context.SaveChanges();
            Console.WriteLine("Attendance recorded successfully.");

            #endregion

        }
        #endregion

        #region View Course Attendance

        public static void ViewCourseAttendance(AppDbContext context)
        {
            Console.WriteLine("\n===|| View Course Attendance ||===");

            Console.Write("Enter Course Code: ");
            var courseCode1 = Console.ReadLine();

            var course1 = context.Courses
                .Where(c => c.CourseCode == courseCode1)
                .Select(c => c.Id)
                .FirstOrDefault();

            if (course1 == 0)
            {
                Console.WriteLine("Course does not exist.");
                return;
            }

            var courseSchedules1 = context.Set<CourseSchedule>()
                .Where(cs => cs.CourseId == course1)
                .Include(cs => cs.Schedule) 
                .OrderBy(cs => cs.Schedule.Date) 
                .ToList();

            if (!courseSchedules1.Any())
            {
                Console.WriteLine("No schedules found for this course.");
                return;
            }

            var students1 = context.Set<CourseStudent>()
                .Where(cs => cs.CourseId == course1)
                .Include(cs => cs.Student)
                .ToList();

            if (!students1.Any())
            {
                Console.WriteLine("No students enrolled in this course.");
                return;
            }
                        
            Console.Write("Name".PadRight(20) + "ID".PadRight(10));
            foreach (var schedule1 in courseSchedules1)
            {
                Console.Write(schedule1.Schedule.Date.ToShortDateString().PadRight(12));
            }
            Console.WriteLine();


            var allAttendanceRecords = context.StudentAttendances
                .Where(sa => sa.CourseStudent.CourseId == course1)
                .ToList();

            foreach (var student in students1)
            {
                Console.Write(student.Student.Name.PadRight(20) + student.Student.StudentId.ToString().PadRight(10));

                foreach (var courseSchedule in courseSchedules1)
                {
                    var attendanceRecord = allAttendanceRecords
                        .FirstOrDefault(sa => sa.CourseStudentId == student.Id && sa.CourseScheduleId == courseSchedule.Id);

                    if (attendanceRecord != null)
                    {
                        int scheduleIndex = courseSchedules1.IndexOf(courseSchedule) + 1;
                        string propertyName = $"Class{scheduleIndex}";
                        var property = typeof(StudentAttendance).GetProperty(propertyName);

                        if (property != null)
                        {
                            bool isPresent = (bool)property.GetValue(attendanceRecord);
                            Console.Write((isPresent ? "P" : "A").PadRight(12));
                        }
                        else
                        {
                            Console.Write("N/A".PadRight(12));
                        }
                    }
                    else
                    {
                        Console.Write("N/A".PadRight(12));
                    }
                }
                Console.WriteLine();
            }















            // Print attendance data
            //foreach (var student1 in students1)
            //{
            //    Console.Write(student1.Student.Name.PadRight(20) + student1.Student.StudentId.ToString().PadRight(10));

            //    // Get the student's attendance record
            //    var attendanceRecord = context.StudentAttendances
            //        .Where(sa => sa.CourseStudentId == student1.Id)
            //        .FirstOrDefault();

            //    if (attendanceRecord != null)
            //    {
            //        for (int i = 1; i <= courseSchedules1.Count; i++)
            //        {
            //            // Use reflection to dynamically access Class1, Class2, ..., ClassN properties
            //            string propertyName = $"Class{i}";
            //            PropertyInfo property = typeof(StudentAttendance).GetProperty(propertyName);

            //            if (property != null)
            //            {
            //                bool isPresent1 = (bool)property.GetValue(attendanceRecord);
            //                Console.Write((isPresent1 ? "P" : "A").PadRight(12));
            //            }
            //            else
            //            {
            //                Console.Write("N/A".PadRight(12)); // In case of missing property
            //            }
            //        }
            //    }
            //    else
            //    {
            //        // If no attendance record found, mark all as "N/A"
            //        for (int i = 1; i <= courseSchedules1.Count; i++)
            //        {
            //            Console.Write("N/A".PadRight(12));
            //        }
            //    }

            //    Console.WriteLine();
            //}
        }

        #endregion
    }
}
