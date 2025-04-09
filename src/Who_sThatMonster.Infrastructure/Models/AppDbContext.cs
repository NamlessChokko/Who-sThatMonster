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

        public static string ConvertDatabaseUrlToConnectionString(string databaseUrl)
        {
            var uri = new Uri(databaseUrl);
            var userInfo = uri.UserInfo.Split(':');
            return $"Host={uri.Host};Port={uri.Port};Database={uri.AbsolutePath.TrimStart('/')};Username={userInfo[0]};Password={userInfo[1]};SSL Mode=Require;Trust Server Certificate=true";
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
