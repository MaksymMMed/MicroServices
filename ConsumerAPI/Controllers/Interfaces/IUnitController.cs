using BLL.DTO.Request;
using BLL.DTO.Response;
using DAL.Pagination;
using DAL.Parameters;
using Microsoft.AspNetCore.Mvc;

namespace ConsumerAPI.Controllers.Interfaces
{
    public interface IUnitController
    {
        Task<ActionResult> AddUnit([FromQuery] UnitRequest request);
        Task<ActionResult> DeleteUnit(int id);
        Task<ActionResult<IEnumerable<IssueResponse>>> GetConsumeOfUnit(int id);
        Task<ActionResult<IEnumerable<IssueResponse>>> GetIssuesOfUnit(int id);
        Task<ActionResult<PagedList<UnitResponse>>> GetUnitsPagedList([FromQuery] UnitParameters parameters);
        Task<ActionResult> UpdateUnit([FromQuery] UnitRequest request);
    }
}