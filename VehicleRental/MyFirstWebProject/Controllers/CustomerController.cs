
using Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using BL_;
using AutoMapper;
using DTO;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyFirstWebProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CustomerController : ControllerBase
    {
        
        ICustomer_Bl _iuserBl;
        IMapper _mapper;
        public CustomerController(ICustomer_Bl iuser, IMapper mapper)
        {
             _iuserBl= iuser;
            _mapper = mapper;

        }
        // GET api/<MyController>/5
        [AllowAnonymous]
        [HttpGet("{email}/{password}")]
        public async Task<ActionResult<CustomerTbl>> Get(string email, string password)
        {
           //throw new Exception("hooooooooo");
            CustomerTbl user = await _iuserBl.getUser(password, email);
            customer_DTO customerDto = _mapper.Map<CustomerTbl, customer_DTO>(user);
            return Ok(customerDto);
        }

        // POST api/<MyController>
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<CustomerTbl>> Post([FromBody] CustomerTbl user)
        {
            CustomerTbl newUser =await _iuserBl.postUser(user);
            customer_DTO customerDto = _mapper.Map<CustomerTbl, customer_DTO>(user);
            return Ok(customerDto);
        }

        // PUT api/<MyController>/5
        [HttpPut("{email}")]
        public async Task Put(string email, [FromBody] CustomerTbl userToUpdate)
        {
           await _iuserBl.putUser(email, userToUpdate);
        }
    }
    // DELETE api/<MyController>/5
    //  [HttpDelete("{id}")]
    //public void Delete(int id)
    //{
    //}
}

