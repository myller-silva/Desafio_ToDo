namespace Todo.API.Model.User;

public class UpdateUserModel
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }

    public UpdateUserModel(long id, string? name, string? email, string? password)
    {
        Id = id;
        Name = name;
        Email = email;
        Password = password;
    }
}