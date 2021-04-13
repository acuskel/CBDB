using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Collection
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Issue> Issues { get; set; }
        public int UserId { get; set; }
        public bool IsPublic { get; set; }
    }
}
