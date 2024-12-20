namespace AuthApi.Models;

public class User
{
    public Guid Id { get; set; }
    public required string Username { get; set; }
    public required string Password { get; set; }
    public required string Email { get; set; }
}
