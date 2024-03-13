using System.ComponentModel.DataAnnotations;

namespace BookShop.Domain.Dto_s.UserDto_s;

public class UserDto
{
    [Required]
    public string UserName { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    [MinLength(8)]
    [MaxLength(30)]
    public string Password { get; set; }
}
