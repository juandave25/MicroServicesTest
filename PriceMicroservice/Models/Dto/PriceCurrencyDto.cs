using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceMicroservice.Models.Dto
{
    public class PriceCurrencyDto
    {
        public PriceCurrency Currency { get; set; }
        public string Message { get; set; }
    }
}
