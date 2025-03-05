using AttendanceSystem;
using AttendanceSystem.Migrations;

Console.WriteLine("\n=========================================|| Welcome to the Attendance System ||=========================================");
#region Login
using (var context = new AppDbContext())
{
    context.Database.EnsureCreated();
    //Console.WriteLine("Database Created Successfully");
    while (true)
    {
        Console.WriteLine("\n===||  Choose an Option  ||===");
        Console.WriteLine("1.   Login");
        Console.WriteLine("2.   Exit");
        Console.Write("Enter Your Choice: "); int choice = int.Parse(Console.ReadLine());
        if (choice == 1)
        {
            Login(context); break;
        }
        else if (choice == 2)
        {
            Console.WriteLine("Thank you for using the Attendance System"); return;
        }
        else
        {
            Console.WriteLine("Invalid Choice"); break;
        }
    }
}
#endregion
#region Login Page
static void Login(AppDbContext context)
{
    while (true)
    {
        Console.Write("Enter UserID: "); string userId = Console.ReadLine();
        Console.Write("Enter Password: "); string password = Console.ReadLine();
        var user = context.Users.SingleOrDefault(u => u.UserId == userId && u.Password == password);
        if (user == null)
        {
            Console.WriteLine("Invalid UserID or Password");
            continue;
        }
        else
        {
            Console.WriteLine("Login Successful\n\n");
            if (user.RoleId == 1)
            {
                Console.WriteLine("Welcome Admin");
                AdminMenu(context);
            }
            else if (user.RoleId == 2)
            {
                Console.WriteLine("Welcome Teacher");
                TeacherMenu(context);
            }
            else if (user.RoleId == 3)
            {
                Console.WriteLine("Welcome Student");
                StudentMenu(context);
            }
            break;
        }
    }
    
}
#endregion

#region Admin Menu
static void AdminMenu(AppDbContext context)
{
    while (true)
    {
        Console.WriteLine("\n===||  Choose an Option  ||===");
        Console.WriteLine("1.   Add a new Teacher");
        Console.WriteLine("2.   Add a new Student");
        Console.WriteLine("3.   Add a new Course");
        Console.WriteLine("4.   Assign Courses to Students");
        Console.WriteLine("5.   Assign Courses to Teachers");
        Console.WriteLine("6.   Add New Schedule Date");
        Console.WriteLine("7.   Add New Course Schedule");

        Console.WriteLine("8.   View Student Data");
        Console.WriteLine("9.   View Teacher Data");
        Console.WriteLine("10.  View Courses");
        Console.WriteLine("11.  View Schedule");
        Console.WriteLine("12.  View Course Students");
        Console.WriteLine("13.  View Student Courses");
        Console.WriteLine("14.  View Teacher Courses");
        Console.WriteLine("15.  View Class Schedule");
        Console.WriteLine("16.  Exit");
        Console.Write("Enter Your Choice: "); int choice = int.Parse(Console.ReadLine());
             
                      
        switch (choice)
        {
            case 1:
                Teacher.AddTeacher(context);
                Console.WriteLine("\n\nEnter Any Key to Go Back to The Options Terminal"); Console.ReadKey();
                break;
            case 2:
                Student.AddStudent(context);
                Console.WriteLine("\n\nEnter Any Key to Go Back to The Options Terminal"); Console.ReadKey();
                break;
            case 3:
                Course.AddCourse(context);
                Console.WriteLine("\n\nEnter Any Key to Go Back to The Options Terminal"); Console.ReadKey();
                break;
            case 4:
                Student.ViewStudent(context);
                Course.ViewCourse(context);
                Student.AssignCoursesToStudents(context);
                Console.WriteLine("\n\nEnter Any Key to Go Back to The Options Terminal"); Console.ReadKey();
                break;
            case 5:
                Teacher.ViewTeacher(context);
                Course.ViewCourse(context);
                Teacher.AssignCoursesToTeachers(context);
                Console.WriteLine("\n\nEnter Any Key to Go Back to The Options Terminal"); Console.ReadKey();
                break;
            case 6:
                Schedule.AddScheduleDate(context);
                Console.WriteLine("\n\nEnter Any Key to Go Back to The Options Terminal"); Console.ReadKey();
                break;
            case 7:
                Schedule.AddCourseSchedule(context);
                Console.WriteLine("\n\nEnter Any Key to Go Back to The Options Terminal"); Console.ReadKey();
                break;

            case 8:
                Student.ViewStudent(context);
                Console.WriteLine("\n\nEnter Any Key to Go Back to The Options Terminal"); Console.ReadKey();
                break;

            case 9:
                Teacher.ViewTeacher(context);
                Console.WriteLine("\n\nEnter Any Key to Go Back to The Options Terminal"); Console.ReadKey();
                break;

            case 10:
                Course.ViewCourse(context);
                Console.WriteLine("\n\nEnter Any Key to Go Back to The Options Terminal"); Console.ReadKey();
                break;

            case 11:
                Schedule.ViewSchedule(context);
                Console.WriteLine("\n\nEnter Any Key to Go Back to The Options Terminal"); Console.ReadKey();
                break;

            case 12:
                Student.ViewCourseStudents(context);
                Console.WriteLine("\n\nEnter Any Key to Go Back to The Options Terminal"); Console.ReadKey();
                break;

            case 13:
                Student.ViewStudentCourses(context);
                Console.WriteLine("\n\nEnter Any Key to Go Back to The Options Terminal"); Console.ReadKey();
                break;

            case 14:    
                Teacher.ViewTeacherCourses(context);
                Console.WriteLine("\n\nEnter Any Key to Go Back to The Options Terminal"); Console.ReadKey();
                break;

            case 15:
                Schedule.ViewCourseSchedule(context);
                Console.WriteLine("\n\nEnter Any Key to Go Back to The Options Terminal"); Console.ReadKey();
                break;
            case 30:
                StudentAttendance.GiveStudentAttendance(context);
                Console.WriteLine("\n\nEnter Any Key to Go Back to The Options Terminal"); Console.ReadKey();
                break;
            case 16:
                Console.WriteLine("Thank you for using the Attendance System.");
                return;

            default:
                Console.WriteLine("Invalid Choice, try again.");
                break;
        }
    }
}
#endregion

#region Teacher Menu

static void TeacherMenu(AppDbContext context)
{
    while (true)
    {
        Console.WriteLine("\n===||  Choose an Option  ||===");
        Console.WriteLine("1.   Give Attendance");
        Console.WriteLine("2.   View Course Students");
        Console.WriteLine("3.   View Teacher Courses");
        Console.WriteLine("4.   View Class Schedule");
        Console.WriteLine("5.   View Course Attendance");
        Console.WriteLine("6.   Exit");
        Console.Write("Enter Your Choice: "); int choice = int.Parse(Console.ReadLine());
        switch (choice)
        {
            case 1:
                TeacherAttendance.GiveTeacherAttendance(context);
                Console.WriteLine("\n\nEnter Any Key to Go Back to The Options Terminal"); Console.ReadKey();
                break;
            case 2:
                Student.ViewCourseStudents(context);
                Console.WriteLine("\n\nEnter Any Key to Go Back to The Options Terminal"); Console.ReadKey();
                break;
            case 3:
                Teacher.ViewTeacherCourses(context);
                Console.WriteLine("\n\nEnter Any Key to Go Back to The Options Terminal"); Console.ReadKey();
                break;
            case 4:
                Schedule.ViewCourseSchedule(context);
                Console.WriteLine("\n\nEnter Any Key to Go Back to The Options Terminal"); Console.ReadKey();
                break;
            case 5:
                StudentAttendance.ViewCourseAttendance(context);
                Console.WriteLine("\n\nEnter Any Key to Go Back to The Options Terminal"); Console.ReadKey();
                break;
            case 6:
                Console.WriteLine("Thank you for using the Attendance System.");
                return;
            default:
                Console.WriteLine("Invalid Choice, try again.");
                break;
        }
    }
}

#endregion

#region Student Menu

static void StudentMenu(AppDbContext context)
{
    while (true)
    {
        Console.WriteLine("\n===||  Choose an Option  ||===");
        Console.WriteLine("1.   View Courses");
        Console.WriteLine("2.   Give Attendance");
        Console.WriteLine("3.   Exit");
        Console.Write("Enter Your Choice: "); int choice = int.Parse(Console.ReadLine());
        switch (choice)
        {
            case 1:
                Student.ViewStudentCourses(context);
                Console.WriteLine("\n\nEnter Any Key to Go Back to The Options Terminal"); Console.ReadKey();
                break;
            case 2:
                StudentAttendance.GiveStudentAttendance(context);
                Console.WriteLine("\n\nEnter Any Key to Go Back to The Options Terminal"); Console.ReadKey();
                break;
            case 3:
                Console.WriteLine("Thank you for using the Attendance System.");
                return;
            default:
                Console.WriteLine("Invalid Choice, try again.");
                break;
        }
    }
}

#endregion


