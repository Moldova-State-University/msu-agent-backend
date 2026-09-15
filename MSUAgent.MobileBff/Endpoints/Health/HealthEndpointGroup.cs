namespace MSUAgent.MobileBff.Endpoints.Health;

[ApiEndpointGroup("/health")]
public sealed class HealthEndpointGroup : IEndpointGroup
{
    public void MapEndpoints(RouteGroupBuilder group)
    {
        group.MapGet("/", HealthEndpoint.Handle);
    }
}   