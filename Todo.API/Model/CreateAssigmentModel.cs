namespace Todo.API.Model;

public class CreateAssigmentModel
{
    public long UserId { get; private set; }              // obrigatorio
    public string Description { get; private set; }
    public bool Concluded { get; private set; }
    public DateTime ConcluedAt { get; private set; } 
    public DateTime DeadLine { get; private set; }
    public long? AssignmentListId { get; private set; }   // nao obrigatorio 

    public CreateAssigmentModel(long userId, string description, bool concluded, DateTime concluedAt, DateTime deadLine, long? assignmentListId)
    {
        UserId = userId;
        Description = description;
        Concluded = concluded;
        ConcluedAt = concluedAt;
        DeadLine = deadLine;
        AssignmentListId = assignmentListId;
    }
}