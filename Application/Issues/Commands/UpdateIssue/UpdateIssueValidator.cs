using Apllication.Issues.Commands.UpdateIssue;
using FluentValidation;

namespace Apllication.Issues.Commands.CreateIssue
{
    internal class UpdateIssueValidator:AbstractValidator<UpdateIssueCommand>
    {
        public UpdateIssueValidator()
        {
            RuleFor(x => x.Title)
                .MaximumLength(100)
                .NotEmpty();

            RuleFor(x => x.Description)
                .MinimumLength(500);

            RuleFor(x => x.Deadline)
                .NotEmpty()
                .WithMessage("Must be greater than creation date")
                .GreaterThan(DateTime.Now);
        }
    }
}
