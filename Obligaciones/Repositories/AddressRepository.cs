using System;
using Obligaciones.Models;

namespace Obligaciones.Repositories
{
    public class AddressRepository : GenericRepository<Address>, IAddressRepository
    {
        private readonly ObligacionesContext _context;
        public AddressRepository(ObligacionesContext context) : base(context)
        {
            _context = context;
        }
    }
}
