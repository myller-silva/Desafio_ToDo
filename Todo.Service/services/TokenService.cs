using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Todo.Core;
using Todo.Domain.Entities;

namespace Service.services;

public static class TokenService
{
    public static string GenerateToken( User user)
    {
        // var claims = new List<Claim>
        // {
        //     new ("Id", user.Id.ToString()),
        //     new (JwtRegisteredClaimNames.Name, user.Name),
        //     new (JwtRegisteredClaimNames.Email, user.Email),
        //     new (JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        //     new (JwtRegisteredClaimNames.Nbf, ToUnixEpochDate(DateTime.UtcNow).ToString()),
        //     new (JwtRegisteredClaimNames.Iat, ToUnixEpochDate(DateTime.UtcNow).ToString())
        // };

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(Settings.Secret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name,
                    user.Name.ToString()),
                new Claim(ClaimTypes.Role, 
                    user.Password.ToString()) //obs password / role
                // user.Id.ToString()) //obs password / role
                // ,new Claim(ClaimTypes.Email, //obs
                //     user.Email)
            }),
            Expires = DateTime.UtcNow.AddHours(2),
            SigningCredentials = 
                new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}