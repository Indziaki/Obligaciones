using System;
using Obligaciones.Models;

namespace Obligaciones.Repositories
{
    public class ContributorRepository : GenericRepository<Contributor>, IContributorRepository
    {
        private readonly ObligacionesContext _context;
        public ContributorRepository(ObligacionesContext context) : base(context)
        {
            _context = context;
        }
    }
}
