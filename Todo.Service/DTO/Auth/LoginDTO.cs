using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Service.DTO.Auth;

public class LoginDTO
{
    
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    
    [Required]
    [PasswordPropertyText]
    public string Password { get; set; }

    public LoginDTO(string email, string password)
    {
        Email = email;
        Password = password;
    }
}