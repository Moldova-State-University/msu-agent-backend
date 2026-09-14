using Projects;

namespace MSUAgent.Hosting.Aspire.Extentions;

/// <summary>
/// Contains extention methods for <see cref="IResourceBuilder"/> that configure services for distributed MSU agent.
/// </summary>
internal static class DistributedApplicationBuilderExtensions
{
    private static string AspnetcoreEnvironment => Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")
        ?? throw new ArgumentException("ASPNETCORE_ENVIRONMENT");

    public static IResourceBuilder<IResourceWithConnectionString> AddMSUAgentDatabase(
    this IDistributedApplicationBuilder builder,
    string password,
    bool persistDatabase)
    {
        var passwordParameter = builder.AddParameter("password", password, secret: true);

        var sql = builder
            .AddSqlServer("msu-agent-db", passwordParameter)
            .WithDataVolume();

        if (persistDatabase)
        {
            sql.WithLifetime(ContainerLifetime.Persistent);
            sql.Resource.Annotations.OfType<EndpointAnnotation>()
                .Single(ep => ep.Name == "tcp").IsProxied = false;
        }

        var database = sql.AddDatabase("MSUAgentDb");

        return database;
    }

    public static IResourceBuilder<IResourceWithEndpoints> AddMSUAgentApi(
        this IDistributedApplicationBuilder builder,
        IResourceBuilder<IResourceWithConnectionString> msuAgentDb,
        IResourceBuilder<IResource> migrationService)
    {
        return builder.AddProject<MSUAgent_Api>("msu-agent-api")
            .WithEnvironment("ASPNETCORE_ENVIRONMENT", AspnetcoreEnvironment)
            .WithReference(msuAgentDb)
            .WaitForCompletion(migrationService);
    }

    public static IResourceBuilder<IResource> AddMigrationService(
        this IDistributedApplicationBuilder builder,
        IResourceBuilder<IResourceWithConnectionString> database)
    {
        return builder.AddProject<MSUAgent_MigrationService>("msu-agent-migrationservice")
            .WithReference(database)
            .WithEnvironment("DOTNET_ENVIRONMENT", AspnetcoreEnvironment)
            .WaitFor(database);
    }
}