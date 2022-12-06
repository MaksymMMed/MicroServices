using Apllication.Common.Interfaces;
using Application.Common.Exceptions;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apllication.Issues.Commands.UpdateIssue
{
    public class UpdateIssueHandler:IRequestHandler<UpdateIssueCommand,Issue>
    {
        private readonly IEmployeeContext Context;

        public UpdateIssueHandler(IEmployeeContext context)
        {
            Context = context;
        }

        public async Task<Issue> Handle(UpdateIssueCommand request, CancellationToken cancellationToken)
        {
            Issue issue = await Context.Issue.FindAsync(request.Id);

            if (issue == null)
            {
                throw new NotFoundException(nameof(Issue), request.Id);
            }

            issue.Description = request.Description.Trim();
            issue.Title = request.Title.Trim();
            issue.Status = request.Status;
            issue.Deadline = request.Deadline;
            issue.TeamId = request.TeamId;

            await Context.SaveChangesAsync(cancellationToken);

            return issue;
        }
    }
}
