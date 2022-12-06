using Domain.Entities;
using MediatR;

namespace Apllication.Teams.Commands.UpdateTeam
{
    public class UpdateTeamCommand:IRequest<Team>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } 
    }
}
