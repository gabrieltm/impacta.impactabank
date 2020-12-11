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
    public class OperationController : ControllerBase
    {
        public OperationService _service = new OperationService();

        [HttpPost("operation")]
        public IActionResult Operation([FromBody] OperationAccount request)
        {
            var response = _service.Operation(request);

            //ObjectResult or = new ObjectResult(response);
            //or.StatusCode = response.StatusCode;
            //return or;

            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }

        [HttpPost("balance")]
        public IActionResult Balance([FromBody] string request)
        {
            var response = _service.Balance(request);

            //ObjectResult or = new ObjectResult(response);
            //or.StatusCode = response.StatusCode;
            //return or;

            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }

        [HttpPost("transfer")]
        public IActionResult Transfer([FromBody] Transfer request)
        {
            var response = _service.Transfer(request);

            //ObjectResult or = new ObjectResult(response);
            //or.StatusCode = response.StatusCode;
            //return or;

            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }

    }
}
