using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Taxi.Domain.Interfaces
{
    public interface IRepository<T> where T : EntityBase
    {
        Task<T> GetById(string id);
        IQueryable<T> GetAll();
        Task<IEnumerable<T>> ListAll();
        Task<T> Add(T entity);
        Task<T> Delete(T entity);
        Task<T> Delete(string id);
        Task<T> Update(T entity);
    }
}
