using MSUAgent.Api.Endpoints.UserRoles.Endpoints.GetUserRoles;

namespace MSUAgent.Api.Endpoints.UserRoles;

[ApiEndpointGroup("/users-roles")]
public class UserRolesEndpointGroup : IEndpointGroup
{
    public void MapEndpoints(RouteGroupBuilder group)
    {
        group.MapGet("", GetUserRolesEndpoint.Handle);
    }
}