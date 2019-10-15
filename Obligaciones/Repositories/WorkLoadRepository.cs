using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Obligaciones.Models;

namespace Obligaciones.Repositories
{
    public class WorkLoadRepository : GenericRepository<WorkLoad>, IWorkLoadRepository
    {
        private readonly ObligacionesContext _context;
        public WorkLoadRepository(ObligacionesContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<WorkLoad> GetById(long id)
        {
            var result = await base.GetById(id);
            result.WorkLoadRegistries = await _context.WorkLoadRegistries.Where(x => x.WorkLoadId == id).ToListAsync();
            return result;
        }

        public async Task<bool> AddRegistries(long id, IEnumerable<WorkLoadRegistry> registries)
        {
            foreach (var reg in registries)
            {
                reg.WorkLoadId = id;
                _context.WorkLoadRegistries.Add(reg);
            }
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> UpdateRegistry(long id)
        {
            var registry = await _context.WorkLoadRegistries.FindAsync(id);
            registry.Complete = true;
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
    }
}
