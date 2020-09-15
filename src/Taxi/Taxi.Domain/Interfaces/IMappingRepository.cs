using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Taxi.Domain.DTO.Base;

namespace Taxi.Domain.Interfaces
{
    public interface IMappingRepository<Dto> where Dto : DtoBase
    {
        Task<Dto> GetById(string id);
        Task<IEnumerable<Dto>> ListAll();
        IQueryable<Dto> GetAll();
        IQueryable<Dto> GetFiltered(Expression<Func<Dto, bool>> predicate);
        Task<IEnumerable<Dto>> ListFiltered(Expression<Func<Dto, bool>> predicate);
        Task<Dto> Add(Dto dto);
        Task<Dto> Delete(Dto dto);
        Task<Dto> Delete(string id);
        Task<Dto> Update(Dto dto);
    }
}