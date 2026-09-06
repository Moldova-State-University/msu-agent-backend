using MediatR;
using MSUAgent.Application.Queries;

namespace MSUAgent.Api.Endpoints.Status;

[ApiEndpointGroup("/status")]
public sealed class StatusEndpointGroup : IEndpointGroup
{
    public void MapEndpoints(RouteGroupBuilder group)
    {
        group.MapGet("/", async (IMediator mediator) =>
        {
            var status = await mediator.Send(new GetStatusQuery());

            return Results.Ok(status);
        });
    }
}