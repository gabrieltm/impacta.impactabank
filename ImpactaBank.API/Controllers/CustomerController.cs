using ImpactaBank.API.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImpactaBank.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        [HttpGet("get")]
        public Customer Get()
        {
            Customer customer = new Customer();
            customer.Id = 1;
            customer.Name = "John";
            customer.Age = 20;
            return customer;
        }

        [HttpGet("list")]
        public List<Customer> List()
        {
            List<Customer> list = new List<Customer>();

            Customer customer = new Customer();
            customer.Id = 1;
            customer.Name = "John";
            customer.Age = 20;
            list.Add(customer);

            customer = new Customer();
            customer.Id = 2;
            customer.Name = "Mariah";
            customer.Age = 23;
            list.Add(customer);

            customer = new Customer();
            customer.Id = 3;
            customer.Name = "Joseph";
            customer.Age = 40;
            list.Add(customer);

            return list;
        }

        [HttpPost("insert")]
        public void Insert([FromBody] Customer request)
        {

        }
    }
}
