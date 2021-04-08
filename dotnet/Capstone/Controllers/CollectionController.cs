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
    public class CollectionController : ControllerBase
    {
        private ICollectionDAO collectionDAO;
        private IIssueDAO issueDAO;

        public CollectionController(ICollectionDAO collectionDAO)
        {
            this.collectionDAO = collectionDAO;
        }

    

        [HttpGet()]
        public ActionResult<List<Collection>> GetPublicCollections()
        {
            return Ok(collectionDAO.GetPublicCollections());
        }

        [HttpGet("user/{userId}")]
        public ActionResult<List<Collection>> GetCollections(int userId)
        {
            List<Collection> result = collectionDAO.GetCollections(userId);
            return Ok(collectionDAO.GetCollections(userId));
        }

        [HttpGet("{collectionId}")]
        public ActionResult<List<Issue>> GetIssues(int collectionId)
        {
            return Ok(collectionDAO.GetIssues(collectionId));
        }


        [HttpPost]
        public ActionResult AddCollection(Collection collection)
        {
            bool result = collectionDAO.AddCollection(collection);
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
