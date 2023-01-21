using System.Collections.ObjectModel;
using Todo.Core;
using Todo.Domain.Validators;

namespace Todo.Domain.Entities;

public class AssignmentList : Base
{
    public string Name { get; private set; }
    public long UserId { get; private set; } // obrigatorio

    protected virtual Collection<Assignment>? Assignments { get; private set; } = new();

    public AssignmentList() {}
    public AssignmentList(string name, long userId)
    {
        Name = name;
        UserId = userId; 
    }

    

    public void SetName(string name)
    {
        Name = name;
    }

    public override bool Validate()
    {
        var validator = new AssignmentListValidator();
        var validation = validator.Validate(this);

        if (!validation.IsValid)
        {
            foreach (var error in validation.Errors)
            {
                _erros.Add(error.ErrorMessage);
            }

            throw new DomainException("Alguns campos estao invalidos. ", _erros);
        }

        return true;
    }

}