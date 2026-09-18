using MSUAgent.Application.Commands.Users;
using MediatR;

namespace MSUAgent.Api.Endpoints.Users;
public static class CreateUserEndpoint
{
    public static async Task<IResult> Handle(
        CreateUserCommand command,
        IMediator mediator,
        CancellationToken cancellationToken)
    {
        var result = await mediator.Send(command, cancellationToken);

        if (result.IsError)
        {
            return Results.BadRequest(result.ErrorMessage);
        }

        var response = new UserResponse(
        result.Value!.Id,
        result.Value.DisplayName,
        result.Value.Email,
        result.Value.Roles);

        return Results.Ok(response);
    }
}
