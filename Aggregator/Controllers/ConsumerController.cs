using Aggregator.Models;
using Aggregator.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace Aggregator.Controllers
{
    [Route("aggregator/[controller]")]
    [ApiController]
    public class ConsumerController : ControllerBase
    {
        private readonly IConsumerService consumerService;

        public ConsumerController(IConsumerService consumerService)
        {
            this.consumerService = consumerService;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ConsumerModel>> GetConsumerById(string id)
        {
            var response = await consumerService.GetConsumerById(id);
            return Ok(response);
        }
    }
}
