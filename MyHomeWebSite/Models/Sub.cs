using System;
using System.Collections.Generic;

namespace MyHomeWebSite.Models
{
    public partial class Sub
    {
        public int Id { get; set; }
        public int? StudentId { get; set; }
        public string? SubJect { get; set; }
        public int? Score { get; set; }
    }
}
