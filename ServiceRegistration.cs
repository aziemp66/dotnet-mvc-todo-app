using dotnet_mvc_todo_app.Data;
using dotnet_mvc_todo_app.Repositories.Contracts;
using dotnet_mvc_todo_app.Repositories.Implementation.Postgres;
using Microsoft.EntityFrameworkCore;

namespace dotnet_mvc_todo_app;

public static class ServiceRegistration
{
    public static async Task InitializeDbAsync(this IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();

        var dbContext = scope.ServiceProvider.GetRequiredService<TodoAppContext>();
        await dbContext.Database.MigrateAsync();
    }
    public static void AddRepositories(this IServiceCollection services, IConfiguration configuration)
    {
        string? connString = configuration.GetConnectionString("TodoAppContext");
        services.AddDbContext<TodoAppContext>(options => options.UseNpgsql(connString));

        services.AddNpgsql<TodoAppContext>(connString);

        services.AddScoped<ITodoRepository, TodoRepository>();
    }
}