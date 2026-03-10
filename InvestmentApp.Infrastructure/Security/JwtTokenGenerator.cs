using InvestmentApp.Application.Interfaces;
using InvestmentApp.Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace InvestmentApp.Infrastructure.Security;

public class JwtTokenGenerator : ITokenGenerator
{
    public string GenerateToken(User user)
    {

        var secretKey = "SuperSecretKeyForInvestmentAppDoNotShareWithAnyone";
        var symmetricKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        var credentials = new SigningCredentials(symmetricKey, SecurityAlgorithms.HmacSha256Signature);

        var claims = new[]
        {
        new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
        new Claim(JwtRegisteredClaimNames.Email, user.Email),
        new Claim(JwtRegisteredClaimNames.Name, user.Name)
    };

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddHours(2), 
            SigningCredentials = credentials
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var securityToken = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(securityToken);
    }
}