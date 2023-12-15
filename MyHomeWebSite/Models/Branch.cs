using System;
using System.Collections.Generic;

namespace MyHomeWebSite.Models
{
    public partial class Branch
    {
        public Branch()
        {
            Employees = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Head { get; set; } = null!;

        public virtual Employee HeadNavigation { get; set; } = null!;
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
