using Apllication.Common.Interfaces;
using Application.Common.Exceptions;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apllication.Employees.Commands.UpdateEmployee
{
    public class UpdateEmployeeHandler:IRequestHandler<UpdateEmployeeCommand,Employee>
    {
        private readonly IEmployeeContext Context;

        public UpdateEmployeeHandler(IEmployeeContext context)
        {
            Context = context;
        }

        public async Task<Employee> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            Employee employee = await Context.Employee.FindAsync(request.Id);
            
            if (employee == null)
            {
                throw new NotFoundException(nameof(Employee), request.Id);
            }

            employee.FirstName = request.FirstName.Trim();
            employee.LastName = request.LastName.Trim();
            employee.Post = request.Post;
            employee.TeamId = request.TeamId;

            await Context.SaveChangesAsync(cancellationToken);

            return employee;
        }
    }
}
