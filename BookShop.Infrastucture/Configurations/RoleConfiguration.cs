using BookShop.Domain.Entities.UserRole;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookShop.Infrastucture.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasData(DefaultRoles);
    }

    private Role[] DefaultRoles = new[]
    {
        new Role()
        {
            Id = 1,
            IsActive = true,
            CreatedDate = DateTime.UtcNow,
            UpdatedDate = DateTime.UtcNow
        },
        new Role()
        {
            Id = 2,
            IsActive = true,
            CreatedDate = DateTime.UtcNow,
            UpdatedDate = DateTime.UtcNow
        },
        new Role()
        {
            Id = 3,
            IsActive = true,
            CreatedDate = DateTime.UtcNow,
            UpdatedDate = DateTime.UtcNow
        }
    };
}