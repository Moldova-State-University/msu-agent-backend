using MediatR;
using Microsoft.AspNetCore.Mvc;
using MSUAgent.Application.Models.Results;
using MSUAgent.Application.Queries.Chats;

namespace MSUAgent.Api.Endpoints.Chats.Endpoints;

public class ChatEndpoint
{
    public static async Task<IResult> Handle([FromBody] string message, IMediator mediator, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new ChatQuery(message), cancellationToken);

        if (result.IsError)
        {
            return result.ErrorType switch
            {
                ErrorType.Internal => Results.Problem(
                    result.ErrorMessage,
                    statusCode: StatusCodes.Status500InternalServerError),

                _ => Results.BadRequest(result.ErrorMessage)
            };
        }

        return Results.Ok(result.Value);
    }
}