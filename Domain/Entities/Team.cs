using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Team
    {
        public Team()
        {
            Members = new List<Employee>();
            Issues = new List<Issue>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual List<Employee>? Members { get; set; }
        public virtual List<Issue>? Issues { get; set; }
    }
}
