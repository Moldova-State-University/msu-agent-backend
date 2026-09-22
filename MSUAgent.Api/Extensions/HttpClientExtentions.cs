using MSUAgent.Application.Interfaces;
using MSUAgent.Infrastructure.Clients;

namespace MSUAgent.Api.Extensions;

public static class HttpClientExtensions
{
    public static IServiceCollection AddAiHttpClient(this IServiceCollection services/*, IConfiguration configuration*/)
    {
        //var baseUrl = configuration["Backend:BaseUrl"] ?? throw new InvalidOperationException("Backend base URL is not configured.");
        services.AddHttpClient<IAiClient, AiClient>(/*"Ai",*/ client =>
        {
            client.BaseAddress = new Uri("https://localhost:7035");
        });

        return services;
    }
}