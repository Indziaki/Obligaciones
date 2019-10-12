using System;
using Obligaciones.Models;

namespace Obligaciones.Repositories
{
    public class DebtRepository : GenericRepository<Debt>, IDebtRepository
    {
        private readonly ObligacionesContext _context;
        public DebtRepository(ObligacionesContext context) : base(context)
        {
            _context = context;
        }
    }
}
