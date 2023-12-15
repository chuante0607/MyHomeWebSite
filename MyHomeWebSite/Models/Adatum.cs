using System;
using System.Collections.Generic;

namespace MyHomeWebSite.Models
{
    public partial class Adatum
    {
        public int Id { get; set; }
        public string Account { get; set; } = null!;
        public string PassWord { get; set; } = null!;
        public string UserId { get; set; } = null!;
    }
}
