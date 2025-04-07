using Microsoft.AspNetCore.Mvc.RazorPages;

public class ShowEnvModel : PageModel
{
    public string? DbUrl { get; set; }

    public void OnGet()
    {
        DbUrl = Environment.GetEnvironmentVariable("DATABASE_URL");
    }
}
