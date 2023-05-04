using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL_;
using Entities;
using DTO;
using AutoMapper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyFirstWebProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesignController : ControllerBase
    {
        IDesigns_BL _Designs_BL;
        IMapper _mapper;
        public DesignController(IDesigns_BL Designs_BL, IMapper mapper)
        {
            _Designs_BL = Designs_BL;
            _mapper = mapper;
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DesignsTbl>> GetDesign(int id)
        {
            return await _Designs_BL.GetDesign(id);
        }
        [HttpGet]
        public async Task<ActionResult<List<DesignsTbl>>> getDesignByTyps(int IdVehicleType, string DescDesign, decimal DesignPrice)
        {
            var listDesign = await _Designs_BL.getDesignByTyps(IdVehicleType, DescDesign, DesignPrice);
           
           // var d = _mapper.Map<List<VehicleDesignsTbl>,List<Design_DTO> >(listDesign).ToList();
            //var g=listDesign.ForEach(o=> _mapper.Map<VehicleDesignsTbl, Design_DTO>(o).DescDesign=DescDesign)
            //d.ForEach(p => p.DescDesign = DescDesign) ;
            //d.ForEach(p => p.DesignPrice = DesignPrice);
            return Ok(listDesign);
        }

    }
}
