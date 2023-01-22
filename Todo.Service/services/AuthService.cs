using Microsoft.AspNetCore.Identity; 
using Service.DTO;
using Service.DTO.Auth;
using Service.interfaces;
using Todo.Core;
using Todo.Domain.Entities;
using Todo.Infra.Interfaces; 
namespace Service.services;

public class AuthService: IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher<User> _passwordHasher;

    public AuthService(IUserRepository userRepository, IPasswordHasher<User> passwordHasher)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task<TokenDTO> Login(LoginDTO userInput)
    {
        var user = await _userRepository.GetByEmail(userInput.Email);
        if (user == null)
            throw new DomainException("Usuario não encontrado!");
        
        var result = _passwordHasher.VerifyHashedPassword(
            user, 
            user.Password, 
            userInput.Password);
        
        if (result == PasswordVerificationResult.Success)
        {
            return GerarToken(user);
        }
        throw new DomainException("Usuario e senha incorretos!");
    }

    public async Task<TokenDTO> Register(RegisterDTO userInput)
    {
        var userExist = await _userRepository.GetByEmail(userInput.Email);
        if (userExist != null)
            throw new DomainException("Já existe usuario com o email cadastrado!");
        var user = new User(
            name: userInput.Name, 
            email: userInput.Email,
            password: "" );
        user.SetPassword(_passwordHasher.HashPassword(user, userInput.Password));

        await _userRepository.Create(user);

        // if (await _userRepository.UnitOfWork.Commit()) 
            return GerarToken(user);

    }


    private TokenDTO GerarToken(User user)
    {
        var hoursExpiracaoToken = 1; // _appSettings.ExpiracaoToken
        var encodedToken =  TokenService.GenerateToken(user);
        return new TokenDTO
        {
            AccessToken = encodedToken,
            ExpiresIn = TimeSpan.FromHours(hoursExpiracaoToken).TotalSeconds,
            User = new UserDTO
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            }
        };
    }
    
    
    private static long ToUnixEpochDate(DateTime date)
        => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero))
            .TotalMilliseconds);


}
