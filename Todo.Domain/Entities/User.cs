using System.Collections.ObjectModel;
using Todo.Core;
using Todo.Domain.Validators;

namespace Todo.Domain.Entities;

public class User : Base
{
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }

    public virtual Collection<Assignment> Assignments { get; private set; } = new();
    public virtual Collection<AssignmentList> AssignmentLists { get; private set; } = new(); 

    public User(string name, string email, string password)
    {
        Name = name;
        Email = email;
        Password = password;
        _erros = new List<string>(); 
    }

    public override bool Validate()
    {
        var validator = new UserValidator();
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
    
    
    public void SetName(string name)
    {
        Name = name;
        Validate();
    }
    
    public void SetPassword(string password)
    {
        Password = password;
        Validate();
    }

    public void SetEmail(string email)
    {
        Email = email;
        Validate();
    }
}