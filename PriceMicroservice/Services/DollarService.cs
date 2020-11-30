using Microsoft.Extensions.Configuration;
using PriceMicroservice.Models;
using PriceMicroservice.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PriceMicroservice.Services
{
    public class DollarService : IService<DollarPrice>
    {
        private readonly string ExternalService;
        private readonly IConfiguration Configuration;
        public DollarService(IConfiguration configuration)
        {
            Configuration = configuration;
            ExternalService = configuration.GetValue<string>("ExternalService");
        }

        public async Task<DollarPrice> GetPrice()
        {
            DollarPrice dollarPrice = new DollarPrice();
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(ExternalService);
            if (response.IsSuccessStatusCode)
            {
                var contentReponse= response.Content.ReadAsStringAsync().Result;
                List<string> priceEntity = contentReponse.Replace("[","").Replace("]","").Replace("\"","").Split(",").ToList();
                dollarPrice = MapEntity(priceEntity);
                return dollarPrice;
            }
            return null;
            
        }

        private DollarPrice MapEntity(List<string> price)
        {
            DollarPrice dollarPrice = new DollarPrice();
            dollarPrice.Sale =  float.Parse(price[0].ToString());
            dollarPrice.Purchase = float.Parse(price[1].ToString());
            dollarPrice.UpdateDate = price[2].ToString();
            return dollarPrice;
        }
    }
}
