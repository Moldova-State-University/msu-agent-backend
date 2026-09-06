namespace MSUAgent.Api.Endpoints.Status;

[ApiEndpointGroup("/status")]
public sealed class StatusEndpointGroup : IEndpointGroup
{
    public void MapEndpoints(RouteGroupBuilder group)
    {
        group.MapGet("/", StatusEndpoint.Handle);
    }
}