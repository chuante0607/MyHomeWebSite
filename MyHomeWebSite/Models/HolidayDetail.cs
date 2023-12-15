using System;
using System.Collections.Generic;

namespace MyHomeWebSite.Models
{
    public partial class HolidayDetail
    {
        public int Id { get; set; }
        public string Eid { get; set; } = null!;
        public int Hid { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public int State { get; set; }
        public string? Remark { get; set; }
        public string? Prove { get; set; }
        public int UsedDays { get; set; }
        public int BelongYear { get; set; }
        public DateTime ApplyDate { get; set; }
        public string? Reason { get; set; }
        public string? AllowManager { get; set; }
        public string RangeDate { get; set; } = null!;

        public virtual Employee EidNavigation { get; set; } = null!;
        public virtual Holiday HidNavigation { get; set; } = null!;
    }
}
