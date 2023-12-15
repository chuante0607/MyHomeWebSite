using System;
using System.Collections.Generic;

namespace MyHomeWebSite.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Branches = new HashSet<Branch>();
            HolidayDetails = new HashSet<HolidayDetail>();
            OverTimeDetails = new HashSet<OverTimeDetail>();
        }

        /// <summary>
        /// 工號
        /// </summary>
        public string Eid { get; set; } = null!;
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; } = null!;
        public string Image { get; set; } = null!;
        public string Branch { get; set; } = null!;
        public string JobTitle { get; set; } = null!;
        public int JobRank { get; set; }
        public string Sex { get; set; } = null!;
        public string? Email { get; set; }
        public string Phone { get; set; } = null!;
        public string? EnglishName { get; set; }
        public string Password { get; set; } = null!;
        public string Shift { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public bool Allow { get; set; }
        public int BranchId { get; set; }

        public virtual Branch BranchNavigation { get; set; } = null!;
        public virtual ICollection<Branch> Branches { get; set; }
        public virtual ICollection<HolidayDetail> HolidayDetails { get; set; }
        public virtual ICollection<OverTimeDetail> OverTimeDetails { get; set; }
    }
}
