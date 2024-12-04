using AuthApi.Data;
using AuthApi.Models;
using AuthApi.Security;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/user")]
public class UserController : ControllerBase
{
    private readonly HashPassword _hashPassword;
    private List<User> _users;
    public readonly UserDbContext _context;

    public UserController(HashPassword hashPassword, UserDbContext userDbContext)
    {
        _context = userDbContext;
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

    [HttpPost]
    public IActionResult Post([FromBody] User _user)
    {
        var user = new User
        {
            Id = Guid.NewGuid(),
            Username = _user.Username,
            Password = _hashPassword.Hash(_user.Password),
            Email = _user.Email,
        };
        _context.Users.Add(user);
        _context.SaveChanges();
        return CreatedAtAction(nameof(Post), user);
    }

    [HttpGet]
    public ActionResult<IEnumerable<User>> Get()
    {
        return _context.Users.ToList();
    }
}
