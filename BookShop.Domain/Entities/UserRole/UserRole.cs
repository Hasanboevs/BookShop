namespace BookShop.Domain.Entities.UserRole;

public class UserRole : Auditable
{
    public int RoleId { get; set; }
    public int UserId { get; set; }
  
}