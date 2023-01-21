using FluentValidation;
using Todo.Domain.Entities;

namespace Todo.Domain.Validators;

public class AssignmentListValidator: AbstractValidator<AssignmentList>
{
    public AssignmentListValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name não pode ser vazio.")
            .NotNull()
            .WithMessage("Name não pode ser nulo.");

        RuleFor(x => x.UserId)
            .NotNull()
            .WithMessage("UserId não pode ser nulo.");
        
    }
}