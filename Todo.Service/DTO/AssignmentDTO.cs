namespace Service.DTO;

public class AssignmentDTO: BaseDTO
{
    
    public long UserId { get; set; }              // obrigatorio
    public string Description { get; set; }
    public bool Concluded { get; set; }
    public DateTime ConcluedAt { get; set; } 
    public DateTime DeadLine { get; set; }
    public long? AssignmentListId { get; set; }

    public AssignmentDTO()
    {
        
    }

    public AssignmentDTO(long userId, string description, bool concluded, DateTime concluedAt, DateTime deadLine, long? assignmentListId)
    {
        UserId = userId;
        Description = description;
        Concluded = concluded;
        ConcluedAt = concluedAt;
        DeadLine = deadLine;
        AssignmentListId = assignmentListId;
    }
}