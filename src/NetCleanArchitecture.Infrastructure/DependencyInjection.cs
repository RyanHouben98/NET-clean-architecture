using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetCleanArchitecture.Application;

namespace NetCleanArchitecture.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddEntityFramework(configuration);
        services.AddRepositories();

        return services;
    }

    private static IServiceCollection AddEntityFramework(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options => 
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork>(options =>
            options.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<ITaskListRepository, TaskListRepository>();

        return services;
    }
}
