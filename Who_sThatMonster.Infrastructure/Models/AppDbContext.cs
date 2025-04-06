using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Who_sThatMonster.Infrastructure.Models;

namespace Who_sThatMonster.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Monster> Monsters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var listToStringConverter = new ValueConverter<List<string>, string>(
                v => string.Join(';', v),
                v => v.Split(';', StringSplitOptions.RemoveEmptyEntries).ToList());

            modelBuilder.Entity<Monster>()
                .Property(m => m.Elements)
                .HasConversion(listToStringConverter);

            modelBuilder.Entity<Monster>()
                .Property(m => m.Habitat)
                .HasConversion(listToStringConverter);
        }
    }
}
