using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImpactaBank.API.Model
{
    public class Operation : BaseResponse
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public DateTime DateTime { get; set; }
        public int AccountRootId { get; set; }
        public int AccountDestinyId { get; set; }
    }
}
