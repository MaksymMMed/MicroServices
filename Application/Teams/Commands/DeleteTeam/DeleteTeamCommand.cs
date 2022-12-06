using Domain.Entities;
using MediatR;

namespace Apllication.Teams.Commands.DeleteTeam
{
    public class DeleteTeamCommand:IRequest<Team>
    {
        public int Id { get; set; } 
    }
}
