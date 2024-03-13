using BookShop.Domain.Dto_s.UserDto_s;
using BookShop.Domain.Interfaces.Users;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthorizeController : ControllerBase
{
    protected readonly IUserService _userService;

    public AuthorizeController(IUserService userService) 
        => _userService = userService;

    [HttpGet]
    public async ValueTask<IActionResult> GetAllUsers() 
        => Ok(await _userService.GetAllUsers());

    [HttpPost]
    public async ValueTask<IActionResult> CreateUser([FromForm]UserDto dto) 
        => Ok(await _userService.CreateAasync(dto));
}
