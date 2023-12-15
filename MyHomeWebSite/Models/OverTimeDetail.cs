using System;
using System.Collections.Generic;

namespace MyHomeWebSite.Models
{
    public partial class OverTimeDetail
    {
        public int Id { get; set; }
        public string Eid { get; set; } = null!;
        public DateTime OverTimeDate { get; set; }
        public bool UserCheck { get; set; }

        public virtual Employee EidNavigation { get; set; } = null!;
    }
}
