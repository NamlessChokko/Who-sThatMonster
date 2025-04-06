using Microsoft.EntityFrameworkCore;

namespace Who_sThatMonster.Infrastructure;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Monster> Monsters { get; set; }
}

