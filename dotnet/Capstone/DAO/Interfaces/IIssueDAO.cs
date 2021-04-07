using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO.Interfaces
{
    public interface IIssueDAO
    {
        List<Issue> GetIssues(int collectionId);
        bool AddIssue(Issue issue);

    }
}
