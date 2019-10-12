using System;
using System.Threading.Tasks;
using Obligaciones.Models;

namespace Obligaciones.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetByUserName(string username);
    }
}
