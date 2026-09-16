using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MSUAgent.TelegramBff.Clients;


namespace MSUAgent.TelegramBff.Extensions;

public static class HttpClientExtensions
{
    public static IServiceCollection AddBackendHttpClient(this IServiceCollection services, IConfiguration configuration)
    {
        var baseUrl = configuration["Backend:BaseUrl"] ?? throw new InvalidOperationException("Backend base URL is not configured.");
        services.AddHttpClient<IMSUAgentClient, MSUAgentClient>("Backend", client =>
        {
            client.BaseAddress = new Uri(baseUrl);
        })
        .AddServiceDiscovery();
        return services;
    }
}
