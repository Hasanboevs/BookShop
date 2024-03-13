using System.Security.Claims;

namespace BookShop.Domain.Interfaces.TokenGenerator;

public interface ITokenGenerator
{
    public string WriteToken(IEnumerable<Claim> claims);
}