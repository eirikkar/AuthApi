using AuthApi.Models;
using AuthApi.Security;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/user")]
public class UserController : ControllerBase
{
    private readonly HashPassword _hashPassword;
    private List<User> _users;

    public UserController(HashPassword hashPassword)
    {
        _hashPassword = hashPassword;
        _users = new List<User>
        {
            new User
            {
                Id = Guid.NewGuid(),
                Username = "user1",
                Password = _hashPassword.Hash("password1"),
                Email = "something@something",
            },
            new User
            {
                Id = Guid.NewGuid(),
                Username = "user2",
                Password = "password2",
                Email = "something@something",
            },
        };
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_users);
    }
}
