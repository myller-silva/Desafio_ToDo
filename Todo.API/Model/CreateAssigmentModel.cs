using System.ComponentModel.DataAnnotations;

namespace Todo.API.Model;

public class CreateAssigmentModel
{
    // public long UserId { get;  set; }              // obrigatorio
    [Required]
    public string Description { get;  set; }
    public bool Concluded { get; set; }
    public DateTime ConcluedAt { get;  set; } 
    public DateTime DeadLine { get;  set; }
    public long? AssignmentListId { get;  set; }   // nao obrigatorio 
    public CreateAssigmentModel()
    {

    }
}