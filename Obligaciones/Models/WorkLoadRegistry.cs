using System;
using System.Collections.Generic;

namespace Obligaciones.Models
{
    public class WorkLoadRegistry
    {
        public WorkLoadRegistry()
        {
        }
        public long WorkLoadRegistryId { get; set; }
        public long WorkLoadId { get; set; }
        public long ContributorId { get; set; }
        public string Name { get; set; }
        public string RFC { get; set; }
        public int Type { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Complete { get; set; }

    }
}
