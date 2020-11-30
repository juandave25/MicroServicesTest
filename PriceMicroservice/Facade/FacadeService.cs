using Microsoft.Extensions.Logging;
using PriceMicroservice.Interfaces;
using PriceMicroservice.Models;
using PriceMicroservice.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceMicroservice.Facade
{
    public class FacadeService
    {

        private readonly ILogger<FacadeService> logger;
        private readonly IService<DollarPrice> dollarService;
        private readonly IService<RealPrice> realService;
        public FacadeService(IService<DollarPrice> DollarService, IService<RealPrice> RealService)
        {
            dollarService = DollarService;
            realService = RealService;
        }
        public FacadeService(ILogger<FacadeService> Logger)
        {
            logger = Logger;
        }

        public async Task<PriceCurrencyDto> GetPriceByCurrency(int currency)
        {
            var response = new PriceCurrencyDto();
            response.Message = "Ok";
            switch (currency)
            {
                case (int)Enum.Currency.dollar:
                    response.Currency = await dollarService.GetPrice();
                    break;
                case (int)Enum.Currency.real:
                    response.Currency = await realService.GetPrice();
                    break;
                default:
                    response.Message = "The currency does not Exist";
                    break;
            }
            return response;
        }
        public async Task<List<PriceCurrency>> GetPrices()
        {
            List<PriceCurrency> priceCurrencies = new List<PriceCurrency>();
            var DollarPrice = new DollarPrice();
            var RealPrice = new RealPrice();
            DollarPrice = await dollarService.GetPrice();
            RealPrice = await realService.GetPrice();
            priceCurrencies.Add(DollarPrice);
            priceCurrencies.Add(RealPrice);

            return priceCurrencies;
        }


    }
}
