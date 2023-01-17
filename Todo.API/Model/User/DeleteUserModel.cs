namespace Todo.API.Model.User;

public class DeleteUserModel
{
    public string Email { get; private set; }
    public string Password { get; private set; }
    
    public DeleteUserModel(string email, string password)
    {
        Email = email;
        Password = password;
    }
}