using AuthApi.Data;
using AuthApi.Models;
using AuthApi.Security;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/user")]
public class UserController : ControllerBase
{
    private readonly HashPassword _hashPassword;
    public readonly UserDbContext _context;

    public UserController(HashPassword hashPassword, UserDbContext userDbContext)
    {
        _context = userDbContext;
        _hashPassword = hashPassword;
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
