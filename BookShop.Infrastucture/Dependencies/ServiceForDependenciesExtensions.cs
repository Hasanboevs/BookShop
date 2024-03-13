using BookShop.Domain.Entities.Books;
using BookShop.Domain.Entities.Users;
using BookShop.Domain.Interfaces.GenericRepositories;
using BookShop.Infrastucture.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BookShop.Infrastucture.Dependencies;

public static class ServiceForDependenciesExtensions
{
    public static void AddDependencies(this IServiceCollection services)
    {
        #region
        
        services.AddScoped<IGenericRepository<User>, GenericRepository<User>>();
        services.AddScoped<IGenericRepository<Book>, GenericRepository<Book>>();

        #endregion
    }
}
