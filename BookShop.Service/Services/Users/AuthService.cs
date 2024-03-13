using BookShop.Domain.Entities.UserRole;
using BookShop.Domain.Entities.Users;
using BookShop.Domain.Interfaces.GenericRepositories;
using BookShop.Domain.Interfaces.TokenGenerator;
using BookShop.Domain.Interfaces.Users;
using BookShop.Infrastucture;
using BookShop.Service.Exceptions;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BookShop.Service.Services.Users;

public class AuthService : IAuthService
{
    protected readonly IGenericRepository<User> _userRepository;
    protected readonly IGenericRepository<Role> _userRoleRepository;
    protected readonly ITokenGenerator tokenGenerator;
    public AuthService(IGenericRepository<User> userRepository, IGenericRepository<Role> userRoleRepository)
    {
        _userRepository = userRepository;
        _userRoleRepository = userRoleRepository;
    }

    public async ValueTask<string> GenerateToken(string email, string password)
    {
        var user = await _userRepository.GetAsync(u => u.Email == email && u.Password.Equals(password.Encrypt()));

        if(user is null)
        {
            throw new BookShopException(404, "login_or_password_is_incorrect");
        }
        var token = await GenerateToken(user);

        return token;
    }
    private ValueTask<string> GenerateToken(User user)
    {
        var claims = new List<Claim>()
        {
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
        };
        
        return ValueTask.FromResult(tokenGenerator.WriteToken(claims));
    }
}
