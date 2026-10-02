using MediatR;

namespace MSUAgent.Application.Queries.Status;

public sealed class GetStatusQueryHandler : IRequestHandler<GetStatusQuery, string>
{
    public Task<string> Handle(GetStatusQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult("MSU Agent is running");
    }
}