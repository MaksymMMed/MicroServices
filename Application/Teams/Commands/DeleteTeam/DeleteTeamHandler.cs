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

namespace Apllication.Teams.Commands.DeleteTeam
{
    public class DeleteTeamHandler:IRequestHandler<DeleteTeamCommand,Team>
    {
        private readonly IEmployeeContext Context;

        public DeleteTeamHandler(IEmployeeContext context)
        {
            Context = context;
        }

        public async Task<Team> Handle(DeleteTeamCommand request, CancellationToken cancellationToken)
        {
            Team team = await Context.Team
                .Where(x => x.Id == request.Id)
                .Include(x => x.Members)
                .FirstOrDefaultAsync();

            if (team == null)
            {
                throw new NotFoundException(nameof(Team), request.Id);
            }

            if (team.Members.Count>0)
            {
                throw new DeleteFailureException(nameof(Team), request.Id, "Assign employees to other teams and then repeat");
            }

            Context.Team.Remove(team);
            await Context.SaveChangesAsync(cancellationToken);
            return team;
        }
    }
}
