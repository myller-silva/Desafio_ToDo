namespace Service.DTO;

public class AssignmentListDTO: BaseDTO
{
    public string Name { get; private set; }
    public long UserId { get; private set; } // obrigatorio

    public AssignmentListDTO(string name, long userId)
    {
        Name = name;
        UserId = userId;
    }
}