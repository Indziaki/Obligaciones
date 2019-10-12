using System;
using Obligaciones.Models;

namespace Obligaciones.Repositories
{
    public class EstateRepository : GenericRepository<Estate>, IEstateRepository
    {
        private readonly ObligacionesContext _context;
        public EstateRepository(ObligacionesContext context) : base(context)
        {
            _context = context;
        }
    }
}
