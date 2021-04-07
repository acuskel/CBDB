using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Issue
    {
        public int IssueId { get; set; }
        public string Title { get; set; }
        public string SeriesTitle { get; set; }
        public int UPC { get; set; }
        public int ISBN { get; set; }
        public string Summary { get; set; }
        //public string Author { get; set; }
        public string Publisher { get; set; }
        public string CoverLink { get; set; }
        public DateTime ReleaseDate { get; set; }

    }
}
