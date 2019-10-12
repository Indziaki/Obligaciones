using System;
namespace Obligaciones.Models
{
    public class Debt
    {
        public Debt()
        {
        }
        public long DebtId { get; set; }
        public long ContributorId { get; set; }
        public long ObligationId { get; set; }
        public int Type { get; set; }
        public int TaxType { get; set; }
        public int Origin { get; set; }
        public double Total { get; set; }
        public DateTime Validity { get; set; }
        public int Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
