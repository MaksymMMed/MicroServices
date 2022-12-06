using Apllication.Issues.Commands.CreateIssue;
using Apllication.Issues.Commands.DeleteIssue;
using Apllication.Issues.Commands.UpdateIssue;
using Apllication.Issues.Queries.GetIssueById;
using Apllication.Issues.Queries.GetIssuesByTeam;
using Apllication.Issues.Queries.GetIssuesByUnit;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPI.Controllers
{
    [Route("employeeapi/[controller]")]
    [ApiController]
    public class IssueController : ControllerBase
    {
        private IMediator mediator;

        public IssueController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("{teamId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetIssuesByTeamId(int teamId)
        {
            var teams = await mediator.Send(new GetIssuesByTeamQuery() { TeamId = teamId });
            if (teams == null)
            {
                return NotFound();
            }
            return Ok(teams);
        }

        [HttpGet("{unitId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetIssuesByUnitId(int unitId)
        {
            var teams = await mediator.Send(new GetIssuesByUnitQuery() { UnitId = unitId });
            if (teams == null)
            {
                return NotFound();
            }
            return Ok(teams);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetIssuesById(int id)
        {
            var teams = await mediator.Send(new GetIssueByIdQuery() { Id = id });
            if (teams == null)
            {
                return NotFound();
            }
            return Ok(teams);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddIssue([FromQuery] CreateIssueCommand command)
        {
            try
            {
                var result = await mediator.Send(command);
                return Ok(result);
            }
            catch
            {
                return BadRequest();
                throw;
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateIssue([FromQuery] UpdateIssueCommand command)
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
        public async Task<IActionResult> DeleteIssue(int id)
        {
            var team = await mediator.Send(new DeleteIssueCommand() {Id=id});
            if (team == null)
            {
                return NotFound();
            }
            return Ok(team);
        }
    }
}
