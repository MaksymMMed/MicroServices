using Apllication.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apllication.Employees.Queries.GetEmployeeById
{
    internal class GetEmployeeByIdHandler:IRequestHandler<GetEmployeeByIdQuery,Employee>
    {
        private readonly IEmployeeContext context;

        public GetEmployeeByIdHandler(IEmployeeContext context)
        {
            this.context = context;
        }

        public async Task<Employee> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            Employee employee = await context.Employee.FindAsync(request.Id);
            return employee;
        }
    }
}
