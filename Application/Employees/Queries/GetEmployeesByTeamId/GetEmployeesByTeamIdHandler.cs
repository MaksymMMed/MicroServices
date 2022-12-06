using Apllication.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apllication.Employees.Queries.GetEmployeesByTeamId
{
    public class GetEmployeesByTeamIdHandler:IRequestHandler<GetEmployeesByTeamIdQuery,List<Employee>>
    {
        private readonly IEmployeeContext context;

        public GetEmployeesByTeamIdHandler(IEmployeeContext context)
        {
            this.context = context;
        }

        public async Task<List<Employee>> Handle(GetEmployeesByTeamIdQuery request, CancellationToken cancellationToken)
        {
            List<Employee> employees = await context.Employee.Where(x => x.TeamId == request.TeamId).ToListAsync();
            return employees;
        }
    }
}
