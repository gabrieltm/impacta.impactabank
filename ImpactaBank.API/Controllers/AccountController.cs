using ImpactaBank.API.Model;
using ImpactaBank.API.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImpactaBank.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        public AccountService _service = new AccountService();        

        [HttpPost("insert")]
        public IActionResult Insert([FromBody] Account request)
        {
            var response = _service.Insert(request);

            //ObjectResult or = new ObjectResult(response);
            //or.StatusCode = response.StatusCode;
            //return or;

            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }
    }
}
