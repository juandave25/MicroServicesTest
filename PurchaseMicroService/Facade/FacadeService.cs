using Microsoft.Extensions.Logging;
using PurchaseMicroService.Models;
using PurchaseMicroService.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PurchaseMicroService.Facade
{
    public class FacadeService
    {
        private readonly ILogger<FacadeService> logger;
        private readonly IRepository<Purchase> purchaseRepository;
        public FacadeService(IRepository<Purchase> PurchaseRepository)
        {
            purchaseRepository = PurchaseRepository;
        }
        public FacadeService(ILogger<FacadeService> Logger)
        {
            logger = Logger;
        }

        public async Task<Purchase> Add(Purchase purchase)
        {
            var response = new Purchase();
            if (ValidateCurrencyLimit(purchase))
            {
                purchase.Price = CalculatePrice(purchase);
                response= await purchaseRepository.Add(purchase);
                return response;
            }   
            return null;
        }

        private float CalculatePrice(Purchase purchase)
        {
            var Price = purchase.Amount / purchase.CurrencyValue;
            return Price;
        }

        private bool ValidateCurrencyLimit(Purchase purchase)
        {
            var validLimit = false;
            if((purchase.Amount==200 && purchase.Currency=="Dollar") || (purchase.Amount == 300 && purchase.Currency == "Real"))
            {
                validLimit = true;
                return validLimit;
            }
            return validLimit;
        }
    }
}
