using Microsoft.EntityFrameworkCore;

namespace Who_sThatMonster.Web.Models;

public class AppDbContext : DbContext

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) 
        : base(options) {}

    public DbSet<Monster> Monsters { get; set; }
}