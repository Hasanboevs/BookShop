namespace BookShop.Domain.Interfaces.Users;

public interface IAuthService
{
    ValueTask<string> GenerateToken(string email, string password);
}
