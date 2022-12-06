using Apllication.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apllication.Teams.Commands.CreateTeam
{
    public class CreateTeamHandler : IRequestHandler<CreateTeamCommand,Team>
    {
        private readonly IEmployeeContext Context;

        public CreateTeamHandler(IEmployeeContext _context)
        {
           Context = _context;
        }

        public async Task<Team> Handle(CreateTeamCommand request, CancellationToken cancellationToken)
        {
            Team team = new()
            {
                Name = request.Name.Trim(),
                Description = request.Description.Trim()
            };

            await Context.Team.AddAsync(team);
            await Context.SaveChangesAsync(cancellationToken);
            return team;
        }
    }
}
