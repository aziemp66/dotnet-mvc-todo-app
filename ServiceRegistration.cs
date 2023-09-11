using dotnet_mvc_todo_app.Data;
using Microsoft.EntityFrameworkCore;

namespace dotnet_mvc_todo_app;

public static class ServiceRegistration
{
    public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
    {
        string? connString = configuration.GetConnectionString("TodoAppContext");
        services.AddDbContext<TodoAppContext>(options => options.UseNpgsql(connString));

        services.AddNpgsql<TodoAppContext>(connString);
    }
}