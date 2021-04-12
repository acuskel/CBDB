using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO.Interfaces
{
    public interface IIssueDAO
    {
        Issue GetIssue(int issueId);
        bool AddIssue(int issueId, int collectionId);
        //bool CreateIssue(Issue issue, int collectionId);

    }
}
