using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImpactaBank.API.Model
{
    public class Account : BaseResponse
    {

        public int Id { get; set; }
        public string Hash { get; set; }
        public int CustomerId { get; set; }
    }
}
