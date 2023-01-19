using System.Collections.ObjectModel;

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
        throw new NotImplementedException("Metodo Validate nao foi implementado");
    }
}