using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Obligaciones.Models;

namespace Obligaciones.Repositories
{
    public interface IWorkLoadRepository : IGenericRepository<WorkLoad>
    {
        Task<bool> AddRegistries(long id, IEnumerable<WorkLoadRegistry> registries);
    }
}
