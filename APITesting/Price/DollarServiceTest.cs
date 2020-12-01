using System;
using Xunit;
using PriceMicroservice.Services;
using PriceMicroservice.Interfaces;
using PriceMicroservice.Models;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace APITesting.Price
{
    [Collection("ActorProjectCollection")]
    public class DollarServiceTest
    {
        readonly DollarService dollarService;
        private const string Uri= "https://www.bancoprovincia.com.ar/Principal/Dolar";

        public DollarServiceTest()
        {
            dollarService = new DollarService(Uri);
        }

        [Fact]
        public async Task GetDollarPrice()
        {
            var Result = await dollarService.GetPrice();
            Assert.IsType<DollarPrice>(Result);
        }
    }
}
