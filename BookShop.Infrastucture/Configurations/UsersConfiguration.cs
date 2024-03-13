using BookShop.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookShop.Infrastucture.Configurations;

internal sealed class UsersConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasData(Data);
    }

    private List<User> Data => new List<User>()
    {
        new User
        {
            Id = 1,
            Email = "admin@gmail.com",
            UserName = "Asror",
            Password = "web123$",
            CreatedDate = new DateTime(2024, 02, 29, 4, 26, 54,461,DateTimeKind.Utc),
            UpdatedDate = new DateTime(2024, 02, 29, 4, 26, 54,461,DateTimeKind.Utc)
        },
        new User
        {
            Id = 2,
            Email = "technicalAdmin@gmail.com",
            UserName = "MuhammadYusuf",
            Password = "Aa@123456",
            CreatedDate = new DateTime(2024, 02, 29, 4, 26, 54,461,DateTimeKind.Utc),
            UpdatedDate = new DateTime(2024, 02, 29, 4, 26, 54,461,DateTimeKind.Utc)
        }
    };
}
