using BookShop.Domain.Interfaces.TokenGenerator;
using BookShop.Domain.Interfaces.Users;
using BookShop.Service.Services.TokenGenerator;
using BookShop.Service.Services.Users;
using Microsoft.Extensions.DependencyInjection;

namespace BookShop.Service.Extensions;

public static class AddServiceScoped
{
    public static void AddCustomScopedService(this IServiceCollection services)
    {
        #region Scoped
        services.AddScoped<ITokenGenerator, TokenGenerator>();
        services.AddScoped<IUserService, UserService>();
        #endregion
    }
}
