using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AttendanceSystem
{
    public class Schedule
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public List<CourseSchedule> CourseSchedules { get; set; }

        #region Add Schedule

        public static void AddScheduleDate(AppDbContext context)
        {
            Console.WriteLine("\n===|| Add New Schedule ||===\n");

            DateOnly date;
            TimeOnly startTime, endTime;

            while (true)
            {
                Console.Write("Enter Schedule Date (yyyy-mm-dd): ");
                var classDate = Console.ReadLine();
                if (!Regex.IsMatch(classDate, @"^\d{4}-(0[1-9]|1[0-2])-(0[1-9]|[12]\d|3[01])$"))
                {
                    Console.WriteLine("Invalid format! Please enter date as yyyy-MM-dd (e.g., 2025-02-28).");
                    continue;
                }
                else
                {
                    date = DateOnly.Parse(classDate);
                    break;
                }
            }

            while (true)
            {
                Console.Write("Enter Class Start Time (HH:MM): ");
                var classStartTime = Console.ReadLine();

                #region Time Format Validation
                if (!Regex.IsMatch(classStartTime, @"^([01]?[0-9]|2[0-3]):[0-5][0-9]$"))
                {
                    Console.WriteLine("Invalid format! Please enter time as HH:mm (e.g., 23:59).");
                    continue;
                }
                else
                {
                    startTime = TimeOnly.Parse(classStartTime);
                    break;
                }
                #endregion
            }

            while (true)
            {
                Console.Write("Enter Class End Time (HH:MM): ");
                var classEndTime = Console.ReadLine();

                #region Time Format Validation
                if (!Regex.IsMatch(classEndTime, @"^([01]?[0-9]|2[0-3]):[0-5][0-9]$"))
                {
                    Console.WriteLine("Invalid format! Please enter time as HH:mm (e.g., 23:59).");
                    continue;
                }
                else
                {
                    endTime = TimeOnly.Parse(classEndTime);
                    break;
                }
                #endregion
            }

            Schedule schedule = new Schedule
            {
                Date = date,
                StartTime = startTime,
                EndTime = endTime
            };

            context.Schedules.Add(schedule);
            context.SaveChanges();
        }

        #endregion

        #region View Schedule
        public static void ViewSchedule(AppDbContext context)
        {
            Console.WriteLine("\n===|| View Schedule ||===");
            var schedules = context.Schedules.ToList();
            if (schedules.Count == 0)
            {
                Console.WriteLine("No Schedule Found");
                return;
            }

            foreach (var schedule in schedules)
            {
                Console.Write($"Date: {schedule.Date}\t");
                Console.Write($"Start Time: {schedule.StartTime}\t");
                Console.Write($"End Time: {schedule.EndTime}");

                //Console.Write("Course Schedules:");
                //if (schedule.CourseSchedules != null)
                //{
                //    foreach (var courseSchedule in schedule.CourseSchedules)
                //    {
                //        Console.WriteLine($"Course Code: {courseSchedule.Course.CourseCode}");
                //        Console.WriteLine($"Class No: {courseSchedule.ClassNo}");
                //    }
                //}
                Console.WriteLine();
            }
        }
        #endregion

        #region Add Course Schedule

        public static void AddCourseSchedule(AppDbContext context)
        {
            Console.WriteLine("\n===|| Add New Course Schedule ||===");

            while (true)
            {
                Console.Write("Enter Course Code: ");
                string courseCode = Console.ReadLine();
                DateOnly scheduleDate;
                while (true)
                {
                    Console.Write("Enter Schedule Date (yyyy-mm-dd): ");
                    var classDate = Console.ReadLine();
                    if (!Regex.IsMatch(classDate, @"^\d{4}-(0[1-9]|1[0-2])-(0[1-9]|[12]\d|3[01])$"))
                    {
                        Console.WriteLine("Invalid format! Please enter date as yyyy-MM-dd (e.g., 2025-02-28).");
                        continue;
                    }
                    else
                    {
                        scheduleDate = DateOnly.Parse(classDate);
                        break;
                    }
                }

                Console.Write("Enter Class Number: ");
                int classNo = Convert.ToInt32(Console.ReadLine());

                var course = context.Courses
                    .FirstOrDefault(c => c.CourseCode == courseCode);

                var schedule = context.Schedules
                    .FirstOrDefault(s => s.Date == scheduleDate);


                if (course == null)
                {
                    Console.WriteLine("Course not found!");
                }
                else if (schedule == null)
                {
                    Console.WriteLine("Schedule not found!");
                }
                else
                {
                    if (schedule.CourseSchedules == null)
                    {
                        schedule.CourseSchedules = new List<CourseSchedule>();
                    }

                    var existingSchedule = schedule.CourseSchedules
                        .SingleOrDefault(cs => cs.CourseId == course.Id && cs.ScheduleId == schedule.Id);
                    if (existingSchedule != null)
                    {
                        Console.WriteLine("Schedule is already assigned to this course.");
                        continue;
                    }

                    schedule.CourseSchedules.Add(new CourseSchedule
                    {
                        CourseId = course.Id,
                        ScheduleId = schedule.Id,
                        ClassNo = classNo
                    });

                    context.SaveChanges();
                    Console.WriteLine("Course Schedule added successfully!"); return;
                }
            }
        }

        #endregion

        #region View Course Schedule

        public static void ViewCourseSchedule(AppDbContext context)
        {
            Console.WriteLine("\n===|| View Course Schedule ||===");
            Console.Write("Enter Course Code: ");
            string courseCode = Console.ReadLine();

            var course = context.Courses
                .Where(c => c.CourseCode == courseCode)
                .Select(c => new { c.CourseCode, c.Id })
                .FirstOrDefault();

            if (course == null)
            {
                Console.WriteLine("Course not found!");
                return;
            }

            var courseSchedules = context.Set<CourseSchedule>()
                .Where(cs => cs.CourseId == course.Id)
                .Include(cs => cs.Schedule) 
                .OrderBy(cs => cs.Schedule.Date) 
                .ToList();

            if (!courseSchedules.Any())
            {
                Console.WriteLine("No schedule found for this course.");
                return;
            }

            foreach (var courseSchedule in courseSchedules)
            {
                Console.Write($"Course Code: {course.CourseCode}\t");
                Console.Write($"Date: {courseSchedule.Schedule.Date.ToShortDateString()}\t");
                Console.Write($"Start Time: {courseSchedule.Schedule.StartTime}\t");
                Console.Write($"End Time: {courseSchedule.Schedule.EndTime}\t\t");
                Console.Write($"Class No: {courseSchedule.ClassNo}");
                Console.WriteLine();
            }

        }

        #endregion
    }
}
