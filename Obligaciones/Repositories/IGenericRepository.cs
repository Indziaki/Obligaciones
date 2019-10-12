using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Obligaciones.Repositories
{
    public interface IGenericRepository<U> where U : class
    {
        Task<IEnumerable<U>> GetAll();
        Task<U> GetById(long id);
        Task<bool> Create(U entity);
        Task<bool> Update(int id, U entity);
        Task<bool> Delete(int id);
    }
}
