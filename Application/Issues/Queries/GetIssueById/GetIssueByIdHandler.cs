using Apllication.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apllication.Issues.Queries.GetIssueById
{
    public class GetIssueByIdHandler : IRequestHandler<GetIssueByIdQuery, Issue>
    {
        private readonly IEmployeeContext Context;

        public GetIssueByIdHandler(IEmployeeContext context)
        {
            Context = context;
        }

        public async Task<Issue> Handle(GetIssueByIdQuery request, CancellationToken cancellationToken)
        {
            var Issue = await Context.Issue.FindAsync(request.Id);

            return Issue;
        }
    }
}
