using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using api_project.Models;
using Microsoft.IdentityModel.Tokens;
using order_manager.Settings;

namespace api_project.Services;

public class TokenService
{
    public string GenerateToken(Client client)
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
                    new Claim("id", client.Id.ToString())
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
