using BookShop.Domain.Entities.UserRole;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookShop.Infrastucture.Configurations;

public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.HasData(DefaultUserRoles);
    }

    private UserRole[] DefaultUserRoles => new[]
    {
        new UserRole()
        {
            Id = 1,
            RoleId = 4,
            UserId = 1,
            CreatedDate = DateTime.UtcNow,
            UpdatedDate = DateTime.UtcNow
        },
        new UserRole()
        {
        Id = 2,
        RoleId = 5,
        UserId = 2,
        CreatedDate = DateTime.UtcNow,
        UpdatedDate = DateTime.UtcNow
        }
    };
}