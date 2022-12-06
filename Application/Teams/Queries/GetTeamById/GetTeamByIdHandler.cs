using Apllication.Common.Interfaces;
using Application.Common.Exceptions;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apllication.Teams.Queries.GetTeamById
{
    public class GetTeamByIdHandler:IRequestHandler<GetTeamByIdQuery,Team>
    {
        private readonly IEmployeeContext Context;

        public GetTeamByIdHandler(IEmployeeContext context)
        {
            Context = context;
        }

        public async Task<Team> Handle(GetTeamByIdQuery request, CancellationToken cancellationToken)
        {
            Team team = await Context.Team.Where(x=>x.Id == request.Id)
                .Include(x=>x.Issues)
                .Include(x=>x.Members)
                .FirstOrDefaultAsync(cancellationToken);

            if (team == null)
            {
                throw new NotFoundException(nameof(Team), request.Id);
            }
            return team;
        }
    }
}
