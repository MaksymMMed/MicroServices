using Apllication.Common.Interfaces;
using Apllication.Teams.Commands.CreateTeam;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apllication.Issues.Commands.CreateIssue
{
    public class CreateIssueHandler:IRequestHandler<CreateIssueCommand,Issue>
    {
        private readonly IEmployeeContext Context;

        public CreateIssueHandler(IEmployeeContext _context)
        {
            Context = _context;
        }

        public async Task<Issue> Handle(CreateIssueCommand request, CancellationToken cancellationToken)
        {
            Issue issue = new()
            {
                Title = request.Title.Trim(),
                Description = request.Description.Trim(),
                CreatiоnDate = DateTime.Now,
                Deadline = request.Deadline,
                TeamId = request.TeamId,
                Status = false
            };
            await Context.Issue.AddAsync(issue);
            await Context.SaveChangesAsync(cancellationToken);
            return issue;
        }
    }
}
