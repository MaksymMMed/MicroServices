using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apllication.Employees.Commands.CreateEmployee
{
    public class CreateEmployeeValidator:AbstractValidator<CreateEmployeeComand>
    {
        CreateEmployeeValidator()
        {
            RuleFor(x => x.FirstName)
                .MaximumLength(50)
                .NotEmpty();

            RuleFor(x => x.LastName)
                .MaximumLength(50)
                .NotEmpty();

            RuleFor(x => x.TeamId)
                .NotNull();

            RuleFor(x => x.Post.PostName)
                .MaximumLength(50)
                .NotEmpty();

            RuleFor(x => x.Post.Entry)
                .LessThanOrEqualTo(DateTime.Now);
        }
    }
}
