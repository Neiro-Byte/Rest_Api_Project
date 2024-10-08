using Microsoft.EntityFrameworkCore;
using Project_Rest_API.Model;


namespace Project_Rest_API
{
    public class UserDbContext : DbContext
  {
    private readonly IConfiguration configuration;
    public DbSet<User> Users { get; set; }
    public UserDbContext(IConfiguration configuration)
    {
      this.configuration = configuration;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
    }
  }
}