namespace Service.DTO;

public class UserDTO: BaseDTO
{ 
    public string Name { get; set; } //apagar os private set pq nao precisa ser uma entidade fechada
    public string Email { get; set; }
    public string Password { get; set; }

    public UserDTO()
    {}
    
    public UserDTO(long id, string name, string email, string password)
    {
        Id = id;
        Name = name;
        Email = email;
        Password = password;
    }
}