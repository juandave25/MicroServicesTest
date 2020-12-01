using PriceMicroservice.Models;
using PriceMicroservice.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace APITesting.Price
{
    [Collection("ActorProjectCollection")]
    public class realpriceservicetest
    {
        readonly RealService realService;
        private const string Uri = "https://www.bancoprovincia.com.ar/Principal/Dolar";

        public realpriceservicetest()
        {
            realService = new RealService(Uri);
        }

        [Fact]
        public async Task GetRealPrice()
        {
            var Result = await realService.GetPrice();
            Assert.IsType<RealPrice>(Result);
        }
    }
}
