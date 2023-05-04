using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL_;
using Entities;
using AutoMapper;
using DTO;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyFirstWebProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class orderController : ControllerBase
    {
        IMapper _mapper;
        IOrders_BL _OrdersBL;
        public orderController(IOrders_BL OrdersBL, IMapper mapper)
        {
            _OrdersBL = OrdersBL;
            _mapper = mapper;
        }

        // POST api/<orederController1>
        [HttpPost]
        public async Task<ActionResult<order_DTO>> Post([FromBody] OrdersTbl Postorder)
        {
            OrdersTbl newOrder = await _OrdersBL.postOrder(Postorder);
            order_DTO d = _mapper.Map<OrdersTbl, order_DTO>(newOrder);
            d.City = newOrder.IdStationNavigation.City;
            d.Street = newOrder.IdStationNavigation.Street;
            d.Neighborhood = newOrder.IdStationNavigation.Neighborhood;
            //return Ok(_mapper.Map<OrdersTbl, order_DTO>(newOrder));
            return Ok(d);
        }

        // DELETE api/<orederController1>/5
        [HttpDelete("{myOrderId}")]
        public async Task deleteOrder(int myOrderId)
        {
                await _OrdersBL.deleteOrder(myOrderId);
        }
    }
}
