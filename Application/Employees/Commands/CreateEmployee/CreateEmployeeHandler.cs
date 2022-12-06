using Apllication.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apllication.Employees.Commands.CreateEmployee
{
    public class CreateEmployeeHandler:IRequestHandler<CreateEmployeeComand,Employee>
    {
        private readonly IEmployeeContext Context;

        public CreateEmployeeHandler(IEmployeeContext context)
        {
            Context = context;
        }

        public async Task<Employee> Handle(CreateEmployeeComand request, CancellationToken cancellationToken)
        {
            var employee = new Employee()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Post = request.Post,
                TeamId = request.TeamId
            };
            await Context.Employee.AddAsync(employee);
            await Context.SaveChangesAsync(cancellationToken);
            return employee;
        }
    }
}
