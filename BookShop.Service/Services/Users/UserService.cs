using BookShop.Domain.Dto_s.UserDto_s;
using BookShop.Domain.Entities.Users;
using BookShop.Domain.Interfaces.GenericRepositories;
using BookShop.Domain.Interfaces.Users;
using BookShop.Domain.Models.UserModels;
using BookShop.Infrastucture;
using BookShop.Service.Exceptions;
using System.Linq.Expressions;

namespace BookShop.Service.Services.Users;

public class UserService : IUserService
{
    private readonly IGenericRepository<User> _userRepository;

    public UserService(IGenericRepository<User> userRepository) 
        => _userRepository = userRepository;

    public async ValueTask<UserModel> CreateAasync(UserDto user)
    {
        var checkUser = await _userRepository.GetAsync(u => u.Email == user.Email);
        if (checkUser is not null)
        {
            throw new BookShopException(400, "this_email_already_exist");
        }

        var model = new User()
        {
            UserName = user.UserName,
            Email = user.Email,
            Password = user.Password.Encrypt(),
            CreatedDate = DateTime.UtcNow,
        };

        var createNew = await _userRepository.CreateAsync(model);
        await _userRepository.SaveChangesAsync();

        return new UserModel().MapFromEntity(model);
    }

    public async ValueTask<bool> DeleteAsync(int id)
    {
        var checkUser = await _userRepository.GetAsync(u => u.Id == id);
        if (checkUser is null)
        {
            throw new BookShopException(404, "user_not_found");
        }

        await _userRepository.DeleteAsync(checkUser.Id);
        await _userRepository.SaveChangesAsync();

        return true;
    }

    public async ValueTask<IEnumerable<UserModel>> GetAllUsers(Expression<Func<User, bool>> expression = null)
    {
        var users = _userRepository.GetAll(expression);
        if (users is null)
        {
            throw new BookShopException(404, "users_not_found");
        }
         
        return users.Select(x => new UserModel().MapFromEntity(x)).ToList();
    }

    public async ValueTask<UserModel> GetAsync(int userId)
    {
        var model = await _userRepository.GetAsync(u => u.Id == userId);
        if (model is null)
        {
            throw new BookShopException(404, "user_not_found");
        }
        return new UserModel().MapFromEntity(model);
    }

    public async ValueTask<UserModel> UpdateAasync(int id, UserDto user)
    {
        var model = await _userRepository.GetAsync(u => u.Id == id);
        if (model is null)
        {
            throw new BookShopException(404, "user_not_found");
        }
        model.UserName = user.UserName;
        model.Password = user.Password;
        model.Email = user.Email;
        model.UpdatedDate = DateTime.UtcNow;

        await _userRepository.SaveChangesAsync();

        return new UserModel().MapFromEntity(model);
    }
}
