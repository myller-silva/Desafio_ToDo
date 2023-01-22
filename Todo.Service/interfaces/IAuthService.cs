using Service.DTO.Auth;

namespace Service.interfaces;

public interface IAuthService
{
    Task<TokenDTO> Login(LoginDTO userInput);
    Task<TokenDTO> Register(RegisterDTO user);
}