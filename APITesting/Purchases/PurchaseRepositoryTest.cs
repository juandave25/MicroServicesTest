using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PurchaseMicroService.Models;

using PurchaseMicroService.Repositories;
using Xunit;

namespace APITesting.Purchases
{
    [Collection("ProjectCollection")]
    public class PurchaseRepositoryTest
    {
        private readonly IRepository<Purchase> Repository;
        public PurchaseRepositoryTest(IRepository<Purchase> repository)
        {
            Repository = repository;
        }

        [Fact]
        public async Task AddPurchase()
        {
            var entity = new Purchase() { User = "123456", Amount = 200, Currency = "Dollar" };
            var Result = await Repository.Add(entity);
            Assert.IsType<Purchase>(Result);
        }
    }
}
