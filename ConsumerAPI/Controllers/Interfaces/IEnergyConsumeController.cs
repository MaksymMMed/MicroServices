using BLL.DTO.Request;
using BLL.DTO.Response;
using DAL.Pagination;
using DAL.Parameters;
using Microsoft.AspNetCore.Mvc;

namespace ConsumerAPI.Controllers.Interfaces
{
    public interface IEnergyConsumeController
    {
        Task<ActionResult> AddEnergyConsume([FromQuery] EnergyConsumeRequest request);
        Task<ActionResult> DeleteEnergyConsume(int id);
        Task<ActionResult<PagedList<EnergyConsumeResponse>>> GetEnergyConsumesPagedList([FromQuery] EnergyConsumeParameters parameters);
        Task<ActionResult> UpdateEnergyConsume([FromQuery] EnergyConsumeRequest request);
    }
}