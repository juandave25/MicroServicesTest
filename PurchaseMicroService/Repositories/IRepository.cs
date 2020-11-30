using PurchaseMicroService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PurchaseMicroService.Repositories
{
    public interface IRepository<T, K> where T : class where K : class
    {
        public Task<T> Add(K entity);
    }
}
