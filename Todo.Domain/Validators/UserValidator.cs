using FluentValidation;
using FluentValidation.Validators;
using Todo.Domain.Entities;

namespace Todo.Domain.Validators;

public class UserValidator: AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(x => x)
            .NotEmpty()
            .WithMessage("O usuário não pode ser vazio")
            
            .NotNull()
            .WithMessage("O usuário não pode ser nulo.");

        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("O Nome não pode ser vazio")
            
            .NotNull()
            .WithMessage("O Nome não pode ser nulo.")
            
            .MinimumLength(3)
            .WithMessage("A propriedade Name deve ter no minimo 3 caracteres.")
            
            .MaximumLength(80)
            .WithMessage("A propriedade Name deve ter no maximo 80 caracteres.");

        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("O Email não pode ser vazio")

            .NotNull()
            .WithMessage("O Email não pode ser nulo.")

            .EmailAddress()
            .WithMessage("Email incompatível.");
        
        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("O Password não pode ser vazio")

            .NotNull()
            .WithMessage("O Password não pode ser nulo.")
            
            .MinimumLength(8)
            .WithMessage("O Password deve ter no mínimo 8 caracteres.")
            
            .MaximumLength(80)
            .WithMessage("O Password não pode passar de 80 caracteres");
        
    }
}