using AuthApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthApi.Data;

public class UserDbContext : DbContext
{
    public required DbSet<User> Users { get; set; }

    public UserDbContext(DbContextOptions<UserDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("Users");
            entity.HasKey(users => users.Id);
            entity.Property(u => u.Username);
            entity.Property(u => u.Password);
            entity.Property(u => u.Email);
        });
    }
}
