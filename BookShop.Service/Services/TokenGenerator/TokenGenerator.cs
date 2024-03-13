using BookShop.Domain.Interfaces.TokenGenerator;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BookShop.Service.Services.TokenGenerator;

internal sealed class TokenGenerator : ITokenGenerator
{
    private readonly IConfiguration _configuration;
    public TokenGenerator(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public string WriteToken(IEnumerable<Claim> claims)
    {
        var authSignInKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));

        var token = new JwtSecurityToken(
            issuer: _configuration["JWT:ValidIssuer"],
            expires: DateTime.Now.AddHours(int.Parse(_configuration["JWT:Expire"])),
            claims: claims,
            signingCredentials: new SigningCredentials(
                key: authSignInKey,
                algorithm: SecurityAlgorithms.HmacSha256)
            );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
