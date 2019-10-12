using System;
namespace Obligaciones.Models
{
    public class Estate
    {
        public Estate()
        {
        }
        public long EstateId { get; set; }
        public long ContributorId { get; set; }
        public string Key { get; set; }
        public double Area { get; set; }
        public double Construction { get; set; }
        public int Type { get; set; }
        public double Price { get; set; }
    }
}
