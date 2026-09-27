using Microsoft.Extensions.DependencyInjection.Extensions;
using MSUAgent.Identity.Application;
using MSUAgent.Identity.Application.Abstractions;
using System.Reflection;

namespace MSUAgent.Identity.Infrastructure.Rest.Extentions;

public static class ServiceCollectionExtentions
{
    public static IServiceCollection AddDomainEvents(
            this IServiceCollection services,
            params Assembly[] assemblies)
    {
        if (assemblies is null || assemblies.Length == 0)
            throw new ArgumentException("At least one assembly must be provided.", nameof(assemblies));

        services.AddScoped<IDomainEventDispatcher, DomainEventDispatcher>();

        services.Scan(scan => scan
            .FromAssemblies(assemblies)
            .AddClasses(c => c.AssignableTo(typeof(IDomainEventHandler<>)), publicOnly: false)
                .As<IDomainEventHandler>()
                .AsSelf()
                .WithScopedLifetime());

        return services;
    }

    public static IServiceCollection AddDomainEvents<TMarker>(this IServiceCollection services)
        => services.AddDomainEvents(typeof(TMarker).Assembly);
}