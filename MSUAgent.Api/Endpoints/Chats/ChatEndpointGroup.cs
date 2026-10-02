using MSUAgent.Api.Endpoints.Chats.Endpoints;

namespace MSUAgent.Api.Endpoints.Chats;

[ApiEndpointGroup("/chat")]
public sealed class ChatEndpointGroup : IEndpointGroup
{
    public void MapEndpoints(RouteGroupBuilder group)
    {
        group.MapPost("/", ChatEndpoint.Handle);
    }
}