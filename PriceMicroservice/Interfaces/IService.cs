using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceMicroservice.Interfaces
{
    public interface IService<T> where T : class
    {
        public Task<T> GetPrice();
    }
}
