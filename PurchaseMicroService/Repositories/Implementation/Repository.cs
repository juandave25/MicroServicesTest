using PurchaseMicroService.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace PurchaseMicroService.Repositories.Implementation
{
    public class Repository<T,K> : IRepository<T,K> where T: class where K : class
    {
        private Context Context;
        private DbSet<T> dbSet;

        public Repository(Context context)
        {
            Context = context;
            dbSet = context.Set<T>();
        }

        public async Task<T> Add(K entity)
        {
            var mappedEntity = MapEntity(entity);
            dbSet.Add(mappedEntity);
            await Context.SaveChangesAsync();
            return mappedEntity;
        }

        private T MapEntity(K entity)
        {
            return (T)Convert.ChangeType(entity, typeof(T));
        }
    }
}
