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
    public class OperationController : ControllerBase
    {
        [HttpPost("withdraw")]
        public void Withdraw([FromBody] Operation request)
        {

        }

        [HttpPost("deposit")]
        public void Deposit([FromBody] Operation request)
        {

        }

        [HttpPost("transfer")]
        public void Transfer([FromBody] Operation request)
        {

        }
    }
}
