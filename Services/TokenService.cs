using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using api_project.Models;
using api_project.Secret;
using Microsoft.IdentityModel.Tokens;

namespace api_project.Services;

public class TokenService
{
    public string GenerateToken(dynamic entity)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(Settings.Secret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(
                new[]
                {
                    new Claim(ClaimTypes.Name, entity.Name),
                    new Claim(ClaimTypes.Email, entity.Email),
                    new Claim("id", entity.Id.ToString())
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
