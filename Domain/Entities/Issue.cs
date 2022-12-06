using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Issue
    {
        public int Id { get; set;}
        public string Title { get; set;}
        public string Description { get; set; }
        public DateTime CreatiоnDate { get; set; }
        public DateTime Deadline { get; set; }
        public bool Status { get; set; }
        public int TeamId { get; set;}
        public int? UnitId { get; set;}
        public virtual Team? Team { get; set;}
        public virtual Unit? Unit { get; set; }
    }
}
