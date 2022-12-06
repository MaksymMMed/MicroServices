using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apllication.Issues.Commands.UpdateIssue
{
    public class UpdateIssueCommand:IRequest<Issue>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; } 
        public bool Status { get; set; } 
        public int TeamId { get; set; } 
        public DateTime Deadline { get; set; } 
    }
}
