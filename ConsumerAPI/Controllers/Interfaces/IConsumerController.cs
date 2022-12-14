using BLL.DTO.Request;
using BLL.DTO.Response;
using DAL.Pagination;
using DAL.Parameters;
using Microsoft.AspNetCore.Mvc;

namespace ConsumerAPI.Controllers.Interfaces
{
    public interface IConsumerController
    {
        Task<ActionResult> AddConsumer([FromQuery] ConsumerRequest consumer);
        Task<ActionResult> DeleteConsumer(int id);
        Task<ActionResult<ConsumerResponse>> GetConsumerById(int id);
        Task<ActionResult<PagedList<ConsumerResponse>>> GetConsumersPagedListAync([FromQuery] ConsumerParameters parameters);
        Task<ActionResult<IEnumerable<EnergyConsumeResponse>>> GetConsumesOfConsumer(int id);
        Task<ActionResult<IEnumerable<UnitResponse>>> GetUnitsOfConsumer(int id);
        Task<ActionResult> UpdateConsumer([FromQuery] ConsumerRequest consumer);
    }
}