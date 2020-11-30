using Microsoft.Extensions.Configuration;
using PriceMicroservice.Interfaces;
using PriceMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PriceMicroservice.Services
{
    public class RealService: IService<RealPrice>
    {
        private readonly string ExternalService;
        private readonly IConfiguration Configuration;
        public RealService(IConfiguration configuration)
        {
            Configuration = configuration;
            ExternalService = configuration.GetValue<string>("ExternalService");
        }

        public async Task<RealPrice> GetPrice()
        {
            RealPrice realPrice = new RealPrice();
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(ExternalService);
            if (response.IsSuccessStatusCode)
            {
                var contentReponse = response.Content.ReadAsStringAsync().Result;
                List<string> priceEntity = contentReponse.Replace("[", "").Replace("]", "").Replace("\"", "").Split(",").ToList();
                realPrice = MapEntity(priceEntity);
                return realPrice;
            }
            return null;

        }

        private RealPrice MapEntity(List<string> price)
        {
            RealPrice realPrice = new RealPrice();
            realPrice.Sale = float.Parse(price[0].ToString())/4;
            realPrice.Purchase = float.Parse(price[1].ToString())/4;
            realPrice.UpdateDate = price[2].ToString();
            return realPrice;
        }
    }
}
