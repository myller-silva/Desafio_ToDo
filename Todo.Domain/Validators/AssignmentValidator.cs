using FluentValidation;
using Todo.Domain.Entities;

namespace Todo.Domain.Validators;

public class AssignmentValidator: AbstractValidator<Assignment>
{
    public AssignmentValidator()
    {
        RuleFor(x => x.Description)
            .MinimumLength(3)
            .WithMessage("A Descricao deve ter no minimo 3 caracteres");

        RuleFor(x => x.UserId)
            .GreaterThan(0)
            .WithMessage("O Id de Usuario deve ser maior que 0");
        


    }
    
}