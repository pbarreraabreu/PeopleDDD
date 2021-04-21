using Microsoft.EntityFrameworkCore;
using PeopleDDD.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PeopleDDD.Infra.Data.Repository
{
    public class BaseRepositorio<T> : IRepository<T> where T : class
    {
        protected readonly PeopleDDDContext context;
        protected readonly DbSet<T> dbSet;

        public BaseRepositorio(PeopleDDDContext context)
        {
            this.context = context;
            dbSet = this.context.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<IEnumerable<T>> FindBy(Expression<Func<T, bool>> predicate)
        {
            return await dbSet.Where(predicate).ToListAsync();            
        }

        public async Task Add(T entity)
        {
            await dbSet.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public Task Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            return context.SaveChangesAsync();
        }

        public Task Remove(T entity)
        {
            dbSet.Remove(entity);
            return context.SaveChangesAsync();
        }       
    }
}
