using Apllication.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apllication.Employees.Queries.GetAllEmployees
{
    public class GetAllEmployeesHandler:IRequestHandler<GetAllEmployeesQuery,List<Employee>>
    {
        private readonly IEmployeeContext Context;

        public GetAllEmployeesHandler(IEmployeeContext context)
        {
            Context = context;
        }

        public async Task<List<Employee>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            List<Employee> employees = await Context.Employee.ToListAsync();
            return employees;
        }
    }
}
