using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apllication.Issues.Queries.GetIssuesByTeam
{
    public class GetIssuesByTeamQuery:IRequest<List<Issue>>
    {
        public int TeamId { get; set; }
    }
}
