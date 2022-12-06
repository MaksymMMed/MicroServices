using Domain.Entities;
using Domain.ValueObject;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apllication.Employees.Commands.UpdateEmployee
{
    public class UpdateEmployeeCommand:IRequest<Employee>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Post Post { get; set; }
        public int TeamId { get; set; }
    }
}
