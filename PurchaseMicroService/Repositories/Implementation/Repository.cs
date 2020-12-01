using Microsoft.EntityFrameworkCore;
using PurchaseMicroService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PurchaseMicroService.Repositories.Implementation
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly Context Context;
        private readonly DbSet<T> dbSet;

        public Repository(Context context)
        {
            Context = context;
            dbSet = context.Set<T>();
        }

        public async Task<T> Add(T entity)
        {
            dbSet.Add(entity);
            await Context.SaveChangesAsync();
            return entity;
        }
    }
}
