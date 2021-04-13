using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.DAO;
using Capstone.DAO.Interfaces;
using Capstone.Models;
using Capstone.DAO;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class IssueController : ControllerBase
    {
        private IIssueDAO issueDAO;
        public IssueController(IIssueDAO issueDAO)
        {
            this.issueDAO = issueDAO;
        }
        [HttpGet("{issueId}")]
        public ActionResult<Issue> GetIssue(int issueId)
        {
            return Ok(issueDAO.GetIssue(issueId));
        }

        [HttpGet("All")]
        public ActionResult<Issue> GetAllIssues()
        {
            return Ok(issueDAO.GetAllIssues());
        }


        [HttpPost("{collectionId}")]
        public ActionResult AddIssue(Issue issue, int collectionId)
        {
            bool result = issueDAO.AddIssue(issue.IssueId, collectionId);
            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        

    }


}
