namespace MSUAgent.MobileBff.Endpoints.Health;

public static class HealthEndpoint
{
    public static async Task<IResult> Handle(IHttpClientFactory httpClientFactory, CancellationToken cancellationToken)
    {
        var client = httpClientFactory.CreateClient("Backend");

        var response = await client.GetAsync("/health", cancellationToken);

        return Results.StatusCode((int)response.StatusCode);
    }
}