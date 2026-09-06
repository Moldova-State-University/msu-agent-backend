using MediatR;

namespace MSUAgent.Application.Queries;

public sealed class GetStatusQueryHandler : IRequestHandler<GetStatusQuery, string>
{
    public Task<string> Handle(GetStatusQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult("MSU Agent is running");
    }
}