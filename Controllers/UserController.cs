using AuthApi.Models;
using AuthApi.Security;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/user")]
public class UserController : ControllerBase
{
    private readonly HashPassword _hashPassword;

    public UserController(HashPassword hashPassword)
    {
        _hashPassword = hashPassword;
    }

    private List<User> _users = new List<User>
    {
        new User
        {
            Id = new Guid(),
            Username = "user1",
            Password = "password1",
            Email = "something@something",
        },
        new User
        {
            Id = new Guid(),
            Username = "user2",
            Password = "password2",
            Email = "something@something",
        },
    };

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_users);
    }
}
