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

        var user = result.Value!;

        var response = new UserResponse(
            user.Id,
            user.DisplayName,
            user.Email,
            user.Roles);

        return Results.Ok(response);
    }
}