using System;
namespace Obligaciones.Models
{
    public class Address
    {
        public Address()
        {
        }
        public long AddressId { get; set; }
        public long ContributorId { get; set; }
        public string Street { get; set; }
        public string Ext { get; set; }
        public string Int { get; set; }
        public string Zip { get; set; }
        public string Suburb { get; set; }
        public string Town { get; set; }
        public string State { get; set; }
    }
}
