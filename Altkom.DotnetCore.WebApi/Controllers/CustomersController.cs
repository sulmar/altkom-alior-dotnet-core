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
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository customerRepository;
        
        public CustomersController(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var customers = customerRepository.Get();

            return Ok(customers);
        }

    }
}
