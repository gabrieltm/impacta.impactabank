using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImpactaBank.API.Model
{
    public class Balance : BaseResponse
    {
        public string Hash { get; set; }
        public decimal Value { get; set; }
    }
}
