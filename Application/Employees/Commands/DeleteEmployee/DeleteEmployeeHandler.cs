using Apllication.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apllication.Employees.Commands.DeleteEmployee
{
    public class DeleteEmployeeHandler:IRequestHandler<DeleteEmployeeCommand,Employee>
    {
        private readonly IEmployeeContext Context;

        public DeleteEmployeeHandler(IEmployeeContext context)
        {
            Context = context;
        }

        public async Task<Employee> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            Employee employee = await Context.Employee.FindAsync(request.Id);

            Context.Employee.Remove(employee);
            Context.SaveChangesAsync(cancellationToken);

            return employee;
        }
    }
}
