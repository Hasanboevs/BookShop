using BookShop.Domain.Dto_s.UserDto_s;
using BookShop.Domain.Entities.Users;
using BookShop.Domain.Models.UserModels;
using System.Linq.Expressions;

namespace BookShop.Domain.Interfaces.Users;

public interface IUserService
{
    ValueTask<IEnumerable<UserModel>> GetAllUsers(Expression<Func<User, bool>> expression = null);
    ValueTask<UserModel> GetAsync(int userId);
    ValueTask<UserModel> CreateAasync(UserDto user);
    ValueTask<UserModel> UpdateAasync(int id, UserDto user);
    ValueTask<bool> DeleteAsync(int id);
}
