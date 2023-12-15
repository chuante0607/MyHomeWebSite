using System;
using System.Collections.Generic;

namespace MyHomeWebSite.Models
{
    public partial class Plan
    {
        public Guid Id { get; set; }
        public string PlanTitle { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
