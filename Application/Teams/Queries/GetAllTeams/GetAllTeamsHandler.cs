using Apllication.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apllication.Teams.Queries.GetAllTeams
{
    public class GetAllTeamsHandler : IRequestHandler<GetAllTeamsQuery, List<Team>>
    {
        private readonly IEmployeeContext Context;

        public GetAllTeamsHandler(IEmployeeContext employeeContext )
        {
            this.Context = employeeContext;
        }

        public async Task<List<Team>> Handle(GetAllTeamsQuery request, CancellationToken cancellationToken)
        {
            return await Context.Team
                .Include(x=>x.Issues)
                .Include(x=>x.Members)
                .ToListAsync(cancellationToken);
        }
    }
}
