using System;
namespace Obligaciones.Models
{
    public class Contributor
    {
        public Contributor()
        {
        }
        public long ContributorId { get; set; }
        public string RFC { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
