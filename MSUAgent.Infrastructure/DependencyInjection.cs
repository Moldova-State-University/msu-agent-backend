using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MSUAgent.Application.Interfaces;
using MSUAgent.Infrastructure.Persistence;
using MSUAgent.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MSUAgent.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("MSUAgentDb")));

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserRoleRepository, UserRoleRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}