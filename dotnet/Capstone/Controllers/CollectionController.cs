using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.DAO.Interfaces;
using Capstone.Models;

namespace Capstone.Controllers
{
    public class CollectionController : ControllerBase
    {
        private ICollectionDAO collectionDAO;

        
        [HttpGet]
        public ActionResult<List<Collection>> GetCollections()
        {
            return Ok(collectionDAO.GetCollections());
        }

    }
}
