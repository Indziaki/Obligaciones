using System;
namespace Obligaciones.Models
{
    public class Obligation
    {
        public Obligation()
        {
        }
        public long ObligationId { get; set; }
        public string Key { get; set; }
        public string Description { get; set; }
        public int Type { get; set; }
        public int PersonType { get; set; }
        public DateTime Valitity { get; set; }
        public string Fundament { get; set; }
        public bool AllowUpdates { get; set; }
        public bool ApplyTaxes { get; set; }
    }
}
