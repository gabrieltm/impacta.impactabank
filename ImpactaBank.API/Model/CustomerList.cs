using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImpactaBank.API.Model
{
    public class CustomerList : BaseResponse
    {
        public List<Customer> Customers { get; set; }
    }
}
