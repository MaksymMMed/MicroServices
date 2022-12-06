using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apllication.Issues.Queries.GetIssuesByUnit
{
    public class GetIssuesByUnitQuery:IRequest<List<Issue>>
    {
        public int UnitId { get; set; }
    }
}
