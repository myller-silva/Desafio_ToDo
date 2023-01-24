using System.ComponentModel.DataAnnotations;

namespace Todo.API.Model.Assignment;

public class CreateAssignmentModel
{
    [Required]
    public string Description { get;  set; }
    public bool Concluded { get; set; }
    public DateTime ConcluedAt { get;  set; } 
    public DateTime DeadLine { get;  set; } 
    
    // [Range(  1, long.MaxValue , ErrorMessage = "Id invalido")]
    public long? AssignmentListId { get;  set; } // nao obrigatorio 
}