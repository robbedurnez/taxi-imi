using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Taxi.API.Data;
using Taxi.Domain;
using Taxi.Domain.Interfaces;

namespace Taxi.API.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        protected readonly TaxiContext _taxiContext;

        public Repository(TaxiContext context)
        {
            _taxiContext = context;
        }

        public virtual async Task<T> GetById(string id)
        {
            return await _taxiContext.Set<T>().FindAsync(id);
        }

        public virtual IQueryable<T> GetAll()
        {
            return _taxiContext.Set<T>().AsNoTracking();
        }

        public async Task<IEnumerable<T>> ListAll()
        {
            return await GetAll().ToListAsync();
        }


        public virtual IQueryable<T> GetFiltered(Expression<Func<T, bool>> predicate)
        {
            return _taxiContext.Set<T>()
                   .Where(predicate).AsNoTracking();
        }

        public async virtual Task<IEnumerable<T>> ListFiltered(Expression<Func<T, bool>> predicate)
        {
            return await GetFiltered(predicate).ToListAsync();
        }

        public async Task<T> Add(T entity)
        {
            _taxiContext.Set<T>().Add(entity);
            try
            {
                await _taxiContext.SaveChangesAsync();
            }
            catch
            {
                return null;
            }
            return entity;
        }

        public async Task<T> Update(T entity)
        {
            _taxiContext.Entry(entity).State = EntityState.Modified;
            try
            {
                await _taxiContext.SaveChangesAsync();
            }
            catch
            {
                return null;
            }
            return entity;
        }

        public async Task<T> Delete(T entity)
        {
            _taxiContext.Set<T>().Remove(entity);
            try
            {
                await _taxiContext.SaveChangesAsync();
            }
            catch
            {
                return null;
            }
            return entity;
        }

        public async Task<T> Delete(string id)
        {
            var entity = await GetById(id);
            if (entity == null) return null;
            return await Delete(entity);
        }
    }
}
