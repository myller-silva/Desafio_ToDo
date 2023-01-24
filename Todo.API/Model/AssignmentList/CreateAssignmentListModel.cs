using System.ComponentModel.DataAnnotations;

namespace Todo.API.Model.AssignmentList;

public class CreateAssignmentListModel
{
    [Required(ErrorMessage = "O Nome da Lista de Tasks é obrigatório")]
    public string Name { get;  set; } 
}