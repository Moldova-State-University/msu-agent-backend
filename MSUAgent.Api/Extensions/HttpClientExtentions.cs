using MSUAgent.Application.Interfaces;
using MSUAgent.Infrastructure.Clients;

namespace MSUAgent.Api.Extensions;

public static class HttpClientExtensions
{
    public static IServiceCollection AddAiHttpClient(this IServiceCollection services, IConfiguration configuration)
    {
        var baseUrl = configuration["Ai:BaseUrl"]
            ?? throw new InvalidOperationException(
                "AI service base URL is not configured.");

        services.AddHttpClient<IAiClient, AiClient>(client =>
        {
            client.BaseAddress = new Uri(baseUrl);
        });

        return services;
    }
}