using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL_;
using Entities;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyFirstWebProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class vehicleController : ControllerBase
    {
        IDescVehicle_BL _DescVehicle;
        public vehicleController(IDescVehicle_BL DescVehicle)
        {
            _DescVehicle = DescVehicle;
        }

        // GET api/<vehicle>/5
        [HttpGet("{IdVehicle}")]
      
        public async Task<ActionResult<DescVehicleTbl>> getVehicle(int IdVehicle)
        {
            
            DescVehicleTbl Vehicle = await _DescVehicle.getVehicle(IdVehicle);
            return Ok(Vehicle);
        }

        [HttpGet]
        public async Task<List<DescVehicleTbl>> getVehicleByTypes(int IdVehicleType, [FromQuery] int idStation, [FromQuery] string city, [FromQuery] int NumSeats
           , [FromQuery] DateTime Production, [FromQuery] decimal PricePerDay, [FromQuery] decimal PricePerHour, [FromQuery] string Company, [FromQuery] string TrunckSize, [FromQuery] bool GearBox)
        {
            var Vehicle = await _DescVehicle.getVehicleByTypes(IdVehicleType, idStation, city, NumSeats
            , Production, PricePerDay, PricePerHour, Company, TrunckSize, GearBox);
            if (Vehicle == null)
                return null;
            return Vehicle;
        }
        //[HttpGet]
        //[Route("[action]/{IdVehicleType}")]
        //public async Task<ActionResult<List<DescVehicleTbl>>> getVehicleByType(int IdVehicleType)
        //{
        //   // IdVehicleType = 1;
        //    var Vehicle = await _DescVehicle.getVehicleByType(IdVehicleType);
        //    return Ok(Vehicle);
        //}

        //[HttpGet]
        //[Route("[action]/{idStation}")]
        //public async Task<ActionResult<List<DescVehicleTbl>>> getVehicleByStation(int idStation)
        //{
        //    var Vehicle = await _DescVehicle.getVehicleByStation(idStation);
        //    return Ok(Vehicle);
        //}

        //[HttpGet]
        //[Route("[action]/{city}")]
        //public async Task<ActionResult<List<DescVehicleTbl>>> getVehicleByCity(string city)
        //{
        //    var Vehicle = await _DescVehicle.getVehicleByCity(city);
        //    return Ok(Vehicle);
        //}

    }
}
