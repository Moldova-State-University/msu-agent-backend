using MediatR;
using MSUAgent.TelegramBff.Clients;

namespace MSUAgent.TelegramBff.Queries.Health;

public sealed class HealthQueryHandler : IRequestHandler<HealthQuery, string>
{
    private readonly IMSUAgentClient _msuAgentClient;

    public HealthQueryHandler(IMSUAgentClient msuAgentClient)
    {
        _msuAgentClient = msuAgentClient;
    }

    public async Task<string> Handle(HealthQuery request, CancellationToken cancellationToken)
    {
        var response = await _msuAgentClient.SendHealthRequest(cancellationToken);

        return $"Health: {(int)response.StatusCode}";
    }
}

