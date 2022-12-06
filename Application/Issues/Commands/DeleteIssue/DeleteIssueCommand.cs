using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apllication.Issues.Commands.DeleteIssue
{
    public class DeleteIssueCommand:IRequest<Issue>
    {
        public int Id { get; set; }
    }
}
