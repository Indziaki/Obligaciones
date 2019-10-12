using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Obligaciones.Repositories
{
    public class GenericRepository<U> : IGenericRepository<U> where U : class
    {
        private readonly DbContext _dbContext;

        public GenericRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<bool> Create(U entity)
        {
            await _dbContext.Set<U>().AddAsync(entity);
            var result = await _dbContext.SaveChangesAsync();
            return result > 0;
        }

        public virtual async Task<bool> Delete(int id)
        {
            var entity = await GetById(id);
            _dbContext.Set<U>().Remove(entity);
            var result = await _dbContext.SaveChangesAsync();
            return result > 0;
        }

        public virtual async Task<IEnumerable<U>> GetAll()
        {
            return await _dbContext.Set<U>().ToListAsync();
        }

        public virtual async Task<U> GetById(long id)
        {
            return await _dbContext.Set<U>().FindAsync(id);
        }

        public virtual async Task<bool> Update(int id, U entity)
        {
            _dbContext.Set<U>().Update(entity);
            var result = await _dbContext.SaveChangesAsync();
            return result > 0;
        }
    }
}
