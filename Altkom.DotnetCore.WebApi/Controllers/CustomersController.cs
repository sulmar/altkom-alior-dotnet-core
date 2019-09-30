using Altkom.DotnetCore.FakeRepositories;
using Altkom.DotnetCore.IRepositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Altkom.DotnetCore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Route("api/klienci")]
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
            var customers = customerRepository.Get();

            return Ok(customers);
        }

        // api/customers/10
        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var customer = customerRepository.Get(id);

            return Ok(customer);
        }

        // api/customers/Gdansk
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var customer = customerRepository.GetByCity(id);

            return Ok(customer);
        }

        // api/customers?city=Gdansk&Street=Przymorze
        [HttpGet]
        public IActionResult GetByCity([FromQuery] string city, [FromQuery] string street)
        {
            var customer = customerRepository.GetByCity(city);

            return Ok(customer);
        }
    }
}
