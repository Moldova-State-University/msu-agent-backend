namespace MSUAgent.Api.Endpoints.Users;

[ApiEndpointGroup("/users")]
public class UsersEndpointGroup : IEndpointGroup
{
    public void MapEndpoints(RouteGroupBuilder group)
    {
        group.MapGet("/{id:guid}", GetUserEndpoint.Handle);
    }
}