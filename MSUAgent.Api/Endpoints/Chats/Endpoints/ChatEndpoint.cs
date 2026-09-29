using MediatR;
using Microsoft.AspNetCore.Mvc;
using MSUAgent.Application.Queries.Chats;

namespace MSUAgent.Api.Endpoints.Chats.Endpoints;

public class ChatEndpoint
{
    public static async Task<IResult> Handle([FromBody] string message, IMediator mediator, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new ChatQuery(message), cancellationToken);
        return Results.Ok(result);
    }
}