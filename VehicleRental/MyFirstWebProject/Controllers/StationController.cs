using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using DL;
using BL_;
using NLog.Web;
using Microsoft.Extensions.Logging;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyFirstWebProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StationController : ControllerBase
    {
        IStation_BL _StationBL;
        ILogger<IStation_BL> _logger;

        public StationController(IStation_BL StationBL, ILogger<IStation_BL> logger)
        {
            _logger = logger;
            _StationBL = StationBL;

        }
        // GET api/<StationController>/5
        [HttpGet("{city}")]
        public async Task<ActionResult<List<StationTbl>>> getStationByCity(string city)
        {

            var tmpCity = await _StationBL.getStationByCity(city);
            try
            {
                throw new Exception("exception from station");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message + ex.StackTrace);
            }
            return Ok(tmpCity);
        }



        //// POST api/<StationController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<StationController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<StationController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
   
    }
}
