using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apllication.Teams.Commands.CreateTeam
{
    public class CreateCommandValidator : AbstractValidator<CreateTeamCommand>
    {
        public CreateCommandValidator()
        {
            RuleFor(x => x.Name)
                .MaximumLength(50)
                .NotEmpty();

            RuleFor(x => x.Description)
                .MaximumLength(500);
        }
    }
}
