using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Collection
    {
        public string Name { get; set; }
        public User User { get; set; }
        public List<Issue> Issues { get; set; }
    }
}
