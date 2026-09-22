using MediatR;
using Microsoft.AspNetCore.Mvc;
using MSUAgent.Application.Queries.Chats;

namespace MSUAgent.Api.Endpoints.Chats.Endpoints;

public class ChatEndpoint
{
    public static async Task<IResult> Handle([FromBody] string message, IMediator mediator)
    {
        var result = await mediator.Send(new ChatQuery() { Message = message});
        return Results.Ok(result);
    }
}