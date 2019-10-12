using System;
using Obligaciones.Models;

namespace Obligaciones.Repositories
{
    public class ObligationRepository : GenericRepository<Obligation>, IObligationRepository
    {
        private readonly ObligacionesContext _context;
        public ObligationRepository(ObligacionesContext context) : base(context)
        {
            _context = context;
        }
    }
}
