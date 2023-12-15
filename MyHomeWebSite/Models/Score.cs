using System;
using System.Collections.Generic;

namespace MyHomeWebSite.Models
{
    public partial class Score
    {
        public string SId { get; set; } = null!;
        public string CId { get; set; } = null!;
        public int? SScore { get; set; }
    }
}
