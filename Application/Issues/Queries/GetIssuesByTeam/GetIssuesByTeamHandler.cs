using Apllication.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apllication.Issues.Queries.GetIssuesByTeam
{
    public class GetIssuesByTeamHandler : IRequestHandler<GetIssuesByTeamQuery, List<Issue>>
    {
        private readonly IEmployeeContext Context;

        public GetIssuesByTeamHandler(IEmployeeContext context)
        {
            Context = context;
        }

        public async Task<List<Issue>> Handle(GetIssuesByTeamQuery request, CancellationToken cancellationToken)
        {
            var Issues = await Context.Issue
                .Where(x => x.TeamId == request.TeamId)
                .ToListAsync();

            return Issues;
        }
    }
}
