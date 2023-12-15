using System;
using System.Collections.Generic;

namespace MyHomeWebSite.Models
{
    public partial class Aemployee
    {
        public string UserId { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Unit { get; set; } = null!;
        public string Addr { get; set; } = null!;
        public int Age { get; set; }
        public DateTime? Birthday { get; set; }
        public string SupervisorId { get; set; } = null!;
        public string? Avatar { get; set; }
    }
}
