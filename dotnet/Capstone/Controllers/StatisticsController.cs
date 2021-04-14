using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.DAO.Interfaces;
using Capstone.DAO;
using Capstone.Models;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private IStatisticsDAO statisticsDAO;

        public StatisticsController(IStatisticsDAO statisticsDAO)
        {
            this.statisticsDAO = statisticsDAO;
        }

        [HttpGet()]
        public ActionResult<Statistics> GetStatistics()
        {
            return Ok(statisticsDAO.GetStatistics());
        }
    }
}
