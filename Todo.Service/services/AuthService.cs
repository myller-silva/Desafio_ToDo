using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Service.DTO;
using Service.DTO.Auth;
using Service.interfaces;
using Todo.Core;
using Todo.Domain.Entities;
using Todo.Infra.Interfaces;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

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
        var claims = new List<Claim>
        {
            new ("Id", user.Id.ToString()),
            new (JwtRegisteredClaimNames.Name, user.Name),
            new (JwtRegisteredClaimNames.Email, user.Email),
            new (JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new (JwtRegisteredClaimNames.Nbf, ToUnixEpochDate(DateTime.UtcNow).ToString()),
            new (JwtRegisteredClaimNames.Iat, ToUnixEpochDate(DateTime.UtcNow).ToString())
        };


        var identityClaims = new ClaimsIdentity();
        identityClaims.AddClaims(claims);

        var tokenHandler = new JwtSecurityTokenHandler(); 
        var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
        {
            Subject = identityClaims,
            // Issuer = _appSettings.Issuer, //modificar depois
            // Audience = _appSettings.Audience,
            Issuer = Settings.Issuer, 
            Audience = Settings.Audience,
            Expires = DateTime.UtcNow.AddHours(Settings.ExpiracaoToken),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Settings.Secret)), 
                SecurityAlgorithms.HmacSha256Signature)
        });
        var encodedToken = tokenHandler.WriteToken(token);

        return new TokenDTO
        {
            AccessToken = encodedToken,
            ExpiresIn = TimeSpan.FromHours(Settings.ExpiracaoToken).TotalSeconds,
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
