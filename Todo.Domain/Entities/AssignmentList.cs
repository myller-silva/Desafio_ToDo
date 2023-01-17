namespace Todo.Domain.Entities;

public class AssignmentList : Base
{
    public string Name { get; private set; }
    public long UserId { get; private set; } // obrigatorio
    
    public override bool Validate()
    {
        throw new NotImplementedException("Metodo Validate nao foi implementado");
    }
}