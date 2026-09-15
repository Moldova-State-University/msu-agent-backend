using MSUAgent.MobileBff.Clients;

namespace MSUAgent.MobileBff.Endpoints.Health;

public static class HealthEndpoint
{
    public static async Task<IResult> Handle(IMSUAgentClient msuAgentClient, CancellationToken cancellationToken)
    {
        var response = await msuAgentClient.SendHealthRequest(cancellationToken);
        return Results.StatusCode((int)response.StatusCode);
    }
}