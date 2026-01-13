using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace CelestialBodies_MVC;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllersWithViews();

        var app = builder.Build();
        app.UseHsts();
        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthorization();
        app.MapStaticAssets();
        app.MapControllerRoute(name: "default", pattern: "{controller=Site}/{action=Home}").WithStaticAssets();
        app.Run();
    }
}
