using MediatR;
using MSUAgent.Application.Queries.Users;

namespace MSUAgent.Api.Endpoints.Users;

public static class GetUserEndpoint
{
    public static async Task<IResult> Handle(
        Guid id,
        IMediator mediator)
    {
        var user = await mediator.Send(new GetUserQuery(id));

        return user is null
            ? Results.NotFound()
            : Results.Ok(user);
    }
}