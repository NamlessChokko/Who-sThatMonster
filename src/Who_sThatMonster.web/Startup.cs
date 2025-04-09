using Microsoft.EntityFrameworkCore;
using Who_sThatMonster.Infrastructure;


var builder = WebApplication.CreateBuilder(args);

DotNetEnv.Env.Load();

var databaseUrl = Environment.GetEnvironmentVariable("DATABASE_URL");
if (string.IsNullOrEmpty(databaseUrl))
{
    throw new InvalidOperationException("The environment variable 'DATABASE_URL' is not set.");
}

var connectionString = AppDbContext.ConvertDatabaseUrlToConnectionString(databaseUrl);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddRazorPages();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapRazorPages();

app.Run();
