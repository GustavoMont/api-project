using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using api_project.Models;
using api_project.Settings;
using Microsoft.IdentityModel.Tokens;

namespace order_manager.Services;

public static class TokenService
{
    public static string GenerateToken(Client client)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(Settings.Secret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(
                new[]
                {
                    new Claim(ClaimTypes.Name, client.Name),
                    new Claim(ClaimTypes.Email, client.Email),
                    new Claim(ClaimTypes.NameIdentifier, client.Id.ToString())
                }
            ),
            Expires = DateTime.Now.AddHours(8),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature
            )
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
