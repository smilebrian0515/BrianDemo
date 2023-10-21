using BrianDemo.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace BrianDemo.Config;

public class TestDbContext : DbContext
{
    public TestDbContext(DbContextOptions<TestDbContext> options) : base(options)
    {
    }

    public DbSet<User> User { get; set; } = null!;
}