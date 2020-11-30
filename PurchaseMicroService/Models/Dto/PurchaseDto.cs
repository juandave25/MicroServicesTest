using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PurchaseMicroService.Models.Dto
{
    public class PurchaseDto
    {
        public string User { get; set; }
        public int Amount { get; set; }
        public string Currency { get; set; }
    }
}
