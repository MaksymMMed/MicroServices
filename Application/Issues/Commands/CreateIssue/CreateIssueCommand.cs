using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apllication.Issues.Commands.CreateIssue
{
    public class CreateIssueCommand:IRequest<Issue>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public int TeamId { get; set; }
    }
}
