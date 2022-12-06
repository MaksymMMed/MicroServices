using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apllication.Employees.Queries.GetEmployeesByTeamId
{
    public class GetEmployeesByTeamIdQuery:IRequest<List<Employee>>
    {
        public int TeamId { get; set; }
    }
}
