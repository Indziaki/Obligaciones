using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Obligaciones.Models;

namespace Obligaciones.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly ObligacionesContext _context;
        public UserRepository(ObligacionesContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User> GetByUserName(string username)
        {
            var entity = await _context.Users.Where(x => x.Username.Equals(username)).FirstOrDefaultAsync();
            return entity;
        }
    }
}
