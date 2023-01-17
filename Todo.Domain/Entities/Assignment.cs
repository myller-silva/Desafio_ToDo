namespace Todo.Domain.Entities;

public class Assignment : Base
{
    public string Description { get; private set; }
    public long UserId { get; private set; }              // obrigatorio
    public long? AssignmentListId { get; private set; }   // nao obrigatorio
    public bool Concluded { get; private set; }
    public DateTime ConcluedAt { get; private set; }
    public DateTime DeadLine { get; private set; }
    
    
    
    public override bool Validate()
    {
        throw new NotImplementedException("Metodo Validate nao foi implementado");
    }
}