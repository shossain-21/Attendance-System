using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem
{
    public class CourseSchedule
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public int ScheduleId { get; set; }
        public Schedule Schedule { get; set; }
        public int ClassNo { get; set; }
    }
}
