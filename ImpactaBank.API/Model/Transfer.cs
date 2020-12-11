using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImpactaBank.API.Model
{
    public class Transfer
    {
        public string HashOrigin { get; set; }
        public string HashDestiny { get; set; }
        public decimal Value { get; set; }
    }
}
