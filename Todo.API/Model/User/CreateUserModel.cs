namespace Todo.API.Model.User;

public class CreateUserModel
{ 
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }

    public CreateUserModel(string name, string email, string password)
    {
        Name = name;
        Email = email;
        Password = password;
    }
}