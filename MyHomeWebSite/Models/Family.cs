using System;
using System.Collections.Generic;

namespace MyHomeWebSite.Models
{
    public partial class Family
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string ChildName { get; set; } = null!;
    }
}
