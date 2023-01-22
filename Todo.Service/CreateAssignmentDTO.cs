using System.ComponentModel.DataAnnotations;

namespace Service;

public class CreateAssignmentDTO
{
    
    [Required]
    public string Description { get; set; }
    public DateTime? Deadline { get; set; }
    public long? AssignmentListId { get; set; } = null;

    public CreateAssignmentDTO(string description, DateTime? deadline, long? assignmentListId)
    {
        Description = description;
        Deadline = deadline;
        AssignmentListId = assignmentListId;
    }
}