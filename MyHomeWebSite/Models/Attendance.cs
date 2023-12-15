using System;
using System.Collections.Generic;

namespace MyHomeWebSite.Models
{
    public partial class Attendance
    {
        public int Id { get; set; }
        public DateTime WorkDate { get; set; }
        public string? Shift { get; set; }
        public bool WeekWork { get; set; }
    }
}
