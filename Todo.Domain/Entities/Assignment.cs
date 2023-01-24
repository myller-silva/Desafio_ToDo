using Todo.Core;
using Todo.Domain.Validators;

namespace Todo.Domain.Entities;

public class Assignment : Base
{
    //tirar essa interrogacao
    public long? UserId { get; set; }               // obrigatorio
    public string Description { get;  set; }
    public bool Concluded { get;  set; }
    public DateTime ConcluedAt { get;  set; } 
    public DateTime DeadLine { get;  set; }

    public long? AssignmentListId { get; set; }   // nao obrigatorio
    public AssignmentList? AssignmentList { get; private set; } //obs: essa linha é desnecessaria e pode causar bugs

    public Assignment() {}
    public Assignment(long? userId, string description, long? assignmentListId, bool concluded, DateTime concluedAt, DateTime deadLine)
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
        var validator = new AssignmentValidator();
        var validation = validator.Validate(this);

        if (!validation.IsValid)
        {
            foreach (var error in validation.Errors)
            {
                _erros.Add(error.ErrorMessage);
            }
            throw new DomainException("Alguns campos estao invalidos. ", _erros);
        }

        return true;
    }

}