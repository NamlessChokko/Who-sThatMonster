using Microsoft.EntityFrameworkCore;
using Who_sThatMonster.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// var flyConnectionString = builder.Configuration.GetConnectionString("DefaultConnection")
//     ?? Environment.GetEnvironmentVariable("DATABASE_URL");

// builder.WebHost.ConfigureKestrel(options =>
// {
//     options.ListenAnyIP(8080);
// });

string ConvertDatabaseUrlToConnectionString(string databaseUrl)
{
    var uri = new Uri(databaseUrl);
    var userInfo = uri.UserInfo.Split(':');
    return $"Host={uri.Host};Port={uri.Port};Database={uri.AbsolutePath.TrimStart('/')};Username={userInfo[0]};Password={userInfo[1]};SSL Mode=Require;Trust Server Certificate=true";
}

var databaseUrl = Environment.GetEnvironmentVariable("DATABASE_URL");
if (string.IsNullOrEmpty(databaseUrl))
{
    throw new InvalidOperationException("The environment variable 'DATABASE_URL' is not set.");
}

var connectionString = ConvertDatabaseUrlToConnectionString(databaseUrl);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddRazorPages();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

// using (var scope = app.Services.CreateScope())
// {
//     var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
//     db.Database.Migrate();
// }

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapRazorPages();

app.Run();
