using MediatR;
using MSUAgent.Application.Queries;

namespace MSUAgent.Api.Endpoints.Status
{
    public class StatusEndpoint
    {
        public static async Task<IResult> Handle(IMediator mediator)
        {
            var status = await mediator.Send(new GetStatusQuery());

            return Results.Ok(status);
        }
    }
}
