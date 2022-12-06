using Apllication.Common.Interfaces;
using Application.Common.Exceptions;
using Domain.Entities;
using MediatR;

namespace Apllication.Teams.Commands.UpdateTeam
{
    public class UpdateTeamHandler : IRequestHandler<UpdateTeamCommand, Team>
    {
        private readonly IEmployeeContext Context;

        public UpdateTeamHandler(IEmployeeContext context)
        {
            Context = context;
        }

        public async Task<Team> Handle(UpdateTeamCommand request, CancellationToken cancellationToken)
        {
            Team team = await Context.Team.FindAsync(request.Id);

            if (team == null)
            {
                throw new NotFoundException(nameof(Team), request.Id);
            }
            
            team.Name = request.Name.Trim();
            team.Description = request.Description.Trim();

            await Context.SaveChangesAsync(cancellationToken);
            return team;

        }
    }
}
