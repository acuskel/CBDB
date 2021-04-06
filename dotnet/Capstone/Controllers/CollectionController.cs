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

        public CollectionController(ICollectionDAO collectionDAO)
        {
            this.collectionDAO = collectionDAO;
        }
        
        [HttpGet ("{userId}")]
        public ActionResult<List<Collection>> GetCollections(int userId)
        {
            return Ok(collectionDAO.GetCollections(userId));
        }

    }
}
