namespace Todo.Domain.Entities;

public class Assignment : Base
{
    public long UserId { get; private set; }              // obrigatorio
    public string Description { get; private set; }
    public bool Concluded { get; private set; }
    public DateTime ConcluedAt { get; private set; } 
    public DateTime DeadLine { get; private set; }
    
    public long? AssignmentListId { get; private set; }   // nao obrigatorio
    public AssignmentList? AssignmentList { get; private set; } = new();

    public Assignment(long userId, string description, long? assignmentListId, bool concluded, DateTime concluedAt, DateTime deadLine)
    {
        UserId = userId;
        Description = description;
        AssignmentListId = assignmentListId; 
        Concluded = concluded;
        ConcluedAt = concluedAt;
        DeadLine = deadLine;
    }
    public override bool Validate()
    {
        throw new NotImplementedException("Metodo Validate nao foi implementado");
    }
}