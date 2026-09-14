using MediatR;
using MSUAgent.Application.Models.Results;
using MSUAgent.Application.Queries.Users;

namespace MSUAgent.Api.Endpoints.Users;

public static class GetUserEndpoint
{
    public static async Task<IResult> Handle(
        Guid id,
        IMediator mediator,
        CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetUserQuery(id), cancellationToken);

        if (result.IsError)
        {
            return result.ErrorType switch
            {
                ErrorType.NotFound => Results.NotFound(result.ErrorMessage),
                _ => Results.BadRequest(result.ErrorMessage)
            };
        }

        var response = new UserResponse(
            result.Value!.Id,
            result.Value.DisplayName,
            result.Value.Email,
            result.Value.Roles);

        return Results.Ok(response);
    }
}