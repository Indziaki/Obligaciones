using System;
using System.Collections.Generic;

namespace Obligaciones.Models
{
    public class WorkLoad
    {
        public WorkLoad()
        {
        }
        public long WorkLoadId { get; set; }
        public long UserId { get; set; }
        public string Name { get; set; }

        public ICollection<WorkLoadRegistry> WorkLoadRegistries { get; set; }
    }
}
