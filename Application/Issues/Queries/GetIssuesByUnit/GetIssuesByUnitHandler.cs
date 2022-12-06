using Apllication.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Apllication.Issues.Queries.GetIssuesByUnit
{
    internal class GetIssuesByUnitHandler : IRequestHandler<GetIssuesByUnitQuery, List<Issue>>
    {
        private readonly IEmployeeContext context;

        public GetIssuesByUnitHandler(IEmployeeContext context)
        {
            this.context = context;
        }

        public async Task<List<Issue>> Handle(GetIssuesByUnitQuery request, CancellationToken cancellationToken)
        {
            var Issues = await context.Issue
                .Where(x => x.TeamId == request.UnitId)
                .ToListAsync();

            return Issues;
        }
    }
}
