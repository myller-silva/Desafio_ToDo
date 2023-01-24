namespace Service.DTO;

public class AssignmentListDTO: BaseDTO
{
    public string Name { get; private set; }
    public long UserId { get;  set; } // obrigatorio

    public AssignmentListDTO()
    {
        
    }
    public AssignmentListDTO(string name, long userId)
    {
        Name = name;
        UserId = userId;
    }
}