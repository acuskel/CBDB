﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.DAO.Interfaces;
using Capstone.Models;

namespace Capstone.Controllers
{
    
    [Route("[controller]")]
    [ApiController]
    public class CollectionController : ControllerBase
    {
        private ICollectionDAO collectionDAO;

        //public CollectionController(ICollectioDAO c)
        
        [HttpGet]
        public ActionResult<List<Collection>> GetCollections()
        {
            return Ok(collectionDAO.GetCollections());
        }

    }
}
