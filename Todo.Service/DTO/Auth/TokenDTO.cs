namespace Service.DTO.Auth;

public class TokenDTO
{
    public string AccessToken { get; set; }
    public double ExpiresIn { get; set; }
    public UserDTO User { get; set; }
}