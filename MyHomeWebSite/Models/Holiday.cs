using System;
using System.Collections.Generic;

namespace MyHomeWebSite.Models
{
    public partial class Holiday
    {
        public Holiday()
        {
            HolidayDetails = new HashSet<HolidayDetail>();
        }

        public int Hid { get; set; }
        public string Title { get; set; } = null!;
        public int TotalDays { get; set; }
        public bool ProveType { get; set; }
        public bool AnyOne { get; set; }

        public virtual ICollection<HolidayDetail> HolidayDetails { get; set; }
    }
}
