using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using ConfigurationManager = Microsoft.Extensions.Configuration.ConfigurationManager;

namespace Blazor.Project.Infrastructure.DependencyInjection;

public static class AuthDependencyInjection
{
    public static void AddIoCAuthentication(this IServiceCollection services, ConfigurationManager configurationManager)
    {
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = configurationManager["Jwt:Issuer"],
                ValidAudience = configurationManager["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configurationManager["Jwt:Key"]!))
            };
        });
    }
}