using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Issue
    {
        private string releaseDate = "";
        public int IssueId { get; set; }
        public string Title { get; set; }
        public string SeriesTitle { get; set; }
        public string UPC { get; set; }
        public string ISBN { get; set; }
        public string Summary { get; set; }
        public string Creator { get; set; }
        public string Publisher { get; set; }
        public string CoverLink { get; set; }
        public string ReleaseDate {
            get{
                return releaseDate;
            }
            set{
                string bracketDates = value;
                bracketDates = bracketDates.Replace("[", "");
                bracketDates = bracketDates.Replace("]", "");
                releaseDate = bracketDates;
            }
        }
        //public int IssueNumber { get; set; }
        //public string StoryTitle { get; set; }
        //public string StoryArcName { get; set; }
        public string Characters { get; set; }
        //public string BioLink { get; set; }
        //public string Genre { get; set; }
        public int PageCount { get; set; }
        public string SeriesId { get; set; }
        //public string Country { get; set; }
        //public string Language { get; set; }
        //public string CreatorBio { get; set; }
        //public string PublicationType { get; set; }

    }
}
