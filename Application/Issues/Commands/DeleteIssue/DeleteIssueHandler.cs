using Apllication.Common.Interfaces;
using Application.Common.Exceptions;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Apllication.Issues.Commands.DeleteIssue
{
    public class DeleteIssueHandler:IRequestHandler<DeleteIssueCommand,Issue>
    {
        private readonly IEmployeeContext Context;

        public DeleteIssueHandler(IEmployeeContext context)
        {
            Context = context;
        }

        public async Task<Issue> Handle(DeleteIssueCommand request, CancellationToken cancellationToken)
        {
            Issue issue = await Context.Issue.FindAsync(request.Id);
            if (issue == null)
            {
                throw new NotFoundException(nameof(Issue), request.Id);
            }
            return issue;
        }
    }
}
