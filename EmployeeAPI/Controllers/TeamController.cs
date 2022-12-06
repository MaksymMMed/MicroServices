using Apllication.Teams.Commands.CreateTeam;
using Apllication.Teams.Commands.DeleteTeam;
using Apllication.Teams.Commands.UpdateTeam;
using Apllication.Teams.Queries.GetAllTeams;
using Apllication.Teams.Queries.GetTeamById;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPI.Controllers
{
    [Route("employeeapi/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {

        private IMediator mediator;

        public TeamController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> CreateTeam([FromQuery] CreateTeamCommand Team)
        {
            try
            {
                var result = await mediator.Send(Team);
                return Ok(result);

            }
            catch
            {
                return BadRequest();
                throw;
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllTeams()
        {
            var teams = await mediator.Send(new GetAllTeamsQuery());
            if (teams == null)
            {
                return NotFound();
            }
            return Ok(teams);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetTeam(int id)
        {
            var team = await mediator.Send(new GetTeamByIdQuery { Id = id});
            if (team == null)
            {
                return NotFound();
            }
            return Ok(team);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateTeam([FromQuery] UpdateTeamCommand command)
        {
            var team = await mediator.Send(command);
            if (team == null)
            {
                return NotFound();
            }
            return Ok(team);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteTeam(int id)
        {
            var team = await mediator.Send(new DeleteTeamCommand { Id=id});
            if (team == null)
            {
                return NotFound();
            }
            return Ok(team);
        }
    }
}
