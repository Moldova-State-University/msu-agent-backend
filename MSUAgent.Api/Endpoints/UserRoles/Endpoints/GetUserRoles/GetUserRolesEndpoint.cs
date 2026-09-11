using MediatR;
using MSUAgent.Application.Models.Results;
using MSUAgent.Application.Queries.UserRoles.GetUserRoles;

namespace MSUAgent.Api.Endpoints.UserRoles.Endpoints.GetUserRoles;

public static class GetUserRolesEndpoint
{
    public static async Task<IResult> Handle(IMediator mediator, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetUserRolesQuery(), cancellationToken);

        if (result.IsError)
        {
            return result.ErrorType switch
            {
                ErrorType.NotFound => Results.NotFound(result.ErrorMessage),
                _ => Results.BadRequest(result.ErrorMessage)
            };
        }

        return Results.Ok(new GetUserRolesResponse([.. result.Value!.Select(r => new UserRoleResponse(r.Id, r.Name))]));
    }
}