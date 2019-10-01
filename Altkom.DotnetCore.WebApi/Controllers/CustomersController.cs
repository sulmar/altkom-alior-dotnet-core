using Altkom.DotnetCore.FakeRepositories;
using Altkom.DotnetCore.IRepositories;
using Altkom.DotnetCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Altkom.DotnetCore.WebApi.Controllers
{
    [Authorize(Roles = "Developer, Admin")]
    [Route("api/[controller]")]
   // [Route("api/klienci")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository customerRepository;

        public CustomersController(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }


        // api/customers
        [HttpGet]
        public IActionResult Get()
        {
            if (this.User.IsInRole("Developer"))
            {

            }

            if (!this.User.Identity.IsAuthenticated)
            {
                return Unauthorized();
            }

            var customers = customerRepository.Get();

            return Ok(customers);
        }

        // api/customers/10
        [HttpGet("{id:int}", Name = "GetById")]
        //[Produces("application/xml")]
        public IActionResult Get(int id)
        {
            var customer = customerRepository.Get(id);

            if (customer == null)
                return NotFound();

            return Ok(customer);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Customer customer)
        {
            customerRepository.Add(customer);
            //return Created($"http://localhost:5000/api/customers/{customer.Id}", customer);

            return CreatedAtRoute("GetById" , new { Id = customer.Id }, customer);
        }

        
        // PUT api/customers/10

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Customer customer)
        {
            if (customer.Id != id)
                return BadRequest();

            customerRepository.Update(customer);

            return Ok();
        }

        // api/customers/Gdansk
        [HttpGet("{city}")]
        public IActionResult Get(string city)
        {
            var customer = customerRepository.GetByCity(city);

            return Ok(customer);
        }

        // api/customers?city=Gdansk&Street=Przymorze
        //[HttpGet]
        //public IActionResult GetByCity([FromQuery] string city, [FromQuery] string street)
        //{
        //    var customer = customerRepository.GetByCity(city);

        //    return Ok(customer);
        //}
    }
}
