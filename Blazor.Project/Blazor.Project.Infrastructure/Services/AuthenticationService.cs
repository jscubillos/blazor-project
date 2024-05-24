using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Blazor.Project.Application.Interfaces;
using Blazor.Project.Domain.Authentication;
using Blazor.Project.Domain.Users;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Blazor.Project.Infrastructure.Services;

public class AuthenticationService(IConfiguration configuration) : IAuthenticationService
{
    public JwtToken GenerateJwtToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(configuration["Jwt:Key"]);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email)
            }),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var securityToken = tokenHandler.CreateToken(tokenDescriptor);
        var token =  tokenHandler.WriteToken(securityToken);
        return new JwtToken
        {
            AccessToken = token,
            TokenType = "Bearer",
            Expires = tokenDescriptor.Expires.Value
        };
    }
}