using BookShop.Domain.Entities.Users;

namespace BookShop.Domain.Models.UserModels;

public class UserModel
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }

    public virtual UserModel MapFromEntity(User entity)
    {
        Id = entity.Id;
        UserName = entity.UserName;
        Email = entity.Email;
        Password = entity.Password;
        CreatedDate = entity.CreatedDate;
        UpdatedDate = entity.UpdatedDate;
        return this;
    }
}
