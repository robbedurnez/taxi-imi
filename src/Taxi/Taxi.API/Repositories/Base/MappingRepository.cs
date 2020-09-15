using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Taxi.API.Data;
using Taxi.Domain;
using Taxi.Domain.DTO.Base;
using Taxi.Domain.Interfaces;

namespace Taxi.API.Repositories.Base
{
    public class MappingRepository<T, Dto> : Repository<T>, IMappingRepository<Dto> where T : EntityBase where Dto : DtoBase
    {
        protected readonly IMapper _mapper;
        
        public MappingRepository(TaxiContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public new async Task<Dto> GetById(string id)
        {
            return await _taxiContext.Set<T>().ProjectTo<Dto>(_mapper.ConfigurationProvider).SingleOrDefaultAsync(d => d.Id == id);
        }
        
        public new async Task<IEnumerable<Dto>> ListAll()
        {
            return await _taxiContext.Set<T>().ProjectTo<Dto>(_mapper.ConfigurationProvider).ToListAsync();
        }
        
        public new IQueryable<Dto> GetAll()
        {
            return _taxiContext.Set<T>().ProjectTo<Dto>(_mapper.ConfigurationProvider);
        }
        
        public IQueryable<Dto> GetFiltered(Expression<Func<Dto, bool>> predicate) 
        {
            return _taxiContext
                .Set<T>()
                .AsNoTracking()
                .ProjectTo<Dto>(_mapper.ConfigurationProvider)
                .Where(predicate);
        }
        
        public virtual async Task<IEnumerable<Dto>> ListFiltered(Expression<Func<Dto, bool>> predicate) {
            return
                await GetFiltered(predicate)
                .ToListAsync(); 
        }

        public virtual async Task<Dto> Add(Dto dto)
        {
            var entity = _mapper.Map<T>(dto);
            
            _taxiContext
                .Set<T>()
                .Add(entity);

            try
            {
                await _taxiContext.SaveChangesAsync();
            }
            catch
            {
                return null;
            }

            return _mapper.Map<Dto>(entity);
        }
        
        public virtual async Task<Dto> Delete(Dto dto) {
            var entity = _taxiContext
                .Set<T>()
                .Remove(_mapper.Map<T>(dto));
            
            try
            {
                await _taxiContext.SaveChangesAsync();
            }
            catch
            {
                return null;
            }
            
            return dto;
        }
        
        public new async Task<Dto> Delete(string id) {
            var entity = await GetById(id);
            
            if (entity == null)
                return null;
            
            return await Delete(_mapper.Map<Dto>(entity));
        }
        
        public virtual async Task<Dto> Update(Dto dto) {
            var entity = _mapper.Map<T>(dto);
            
            _taxiContext.Entry(entity).State = EntityState.Modified;
            
            try
            {
                await _taxiContext.SaveChangesAsync(); 
            }
            catch
            {
                return null;
            }
            
            return _mapper.Map<Dto>(entity); }
    }
}