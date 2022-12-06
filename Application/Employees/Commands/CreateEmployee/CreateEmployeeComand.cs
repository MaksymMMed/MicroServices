using Domain.Entities;
using Domain.ValueObject;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apllication.Employees.Commands.CreateEmployee
{
    public class CreateEmployeeComand:IRequest<Employee>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Post Post { get; set; }
        public int TeamId { get; set; }
    }
}
