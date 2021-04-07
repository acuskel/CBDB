﻿using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("{collectionId}")]
        public ActionResult<List<Issue>> GetIssues(int collectionId)
        {
            return Ok(issueDAO.GetIssues(collectionId));
        }

        [HttpPost]
        public ActionResult AddIssue(Issue issue)
        {
            bool result = issueDAO.AddIssue(issue);
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
