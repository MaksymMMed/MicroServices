using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Unit
    {
        public Unit()
        {
            Issues = new();
        }
        public int Id { get; set; }
        public List<Issue>? Issues { get; set; }
    }   
}
