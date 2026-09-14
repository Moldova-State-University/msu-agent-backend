using Microsoft.Extensions.Hosting;

namespace MSUAgent.MigrationService.Extentions;

public static class HostEnvironmentExtensions
{
    public const string LocalEnvironment = "Local";

    public static bool IsLocal(this IHostEnvironment hostEnvironment)
    {
        ArgumentNullException.ThrowIfNull(hostEnvironment);

        return hostEnvironment.IsEnvironment(LocalEnvironment);
    }
}