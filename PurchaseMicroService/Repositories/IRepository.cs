using PurchaseMicroService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PurchaseMicroService.Repositories
{
    public interface IRepository<T> where T : class
    {
        public Task<T> Add(T entity);
    }
}
