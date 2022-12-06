using Apllication.Employees.Commands.CreateEmployee;
using Apllication.Employees.Commands.DeleteEmployee;
using Apllication.Employees.Commands.UpdateEmployee;
using Apllication.Employees.Queries.GetAllEmployees;
using Apllication.Employees.Queries.GetEmployeeById;
using Apllication.Employees.Queries.GetEmployeesByTeamId;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace EmployeeAPI.Controllers
{
    [Route("employeeapi/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IMediator mediator;

        public EmployeeController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllTeams()
        {
            try
            {
                var result = await mediator.Send(new GetAllEmployeesQuery());
                return Ok(result);
            }
            catch
            {
                return BadRequest();
                throw;
            }
        }

        [HttpGet("{teamId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetEmployeesByTeamId(int teamId)
        {
            var teams = await mediator.Send(new GetEmployeesByTeamIdQuery() { TeamId = teamId });
            if (teams == null)
            {
                return NotFound();
            }
            return Ok(teams);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var teams = await mediator.Send(new GetEmployeeByIdQuery() { Id = id });
            if (teams == null)
            {
                return NotFound();
            }
            return Ok(teams);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddEmployee([FromQuery] CreateEmployeeComand command)
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
        public async Task<IActionResult> UpdateEmployee([FromQuery] UpdateEmployeeCommand command)
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
        public async Task<IActionResult> DeleteIssue([FromQuery] DeleteEmployeeCommand command)
        {
            var team = await mediator.Send(command);
            if (team == null)
            {
                return NotFound();
            }
            return Ok(team);
        }
    }
}
