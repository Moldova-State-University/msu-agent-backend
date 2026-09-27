using Microsoft.Extensions.Logging;
using MSUAgent.Identity.Application.Abstractions;
using MSUAgent.Identity.Domain.Events;

namespace MSUAgent.Identity.Application.EventHandlers;

public class IdentityCreatedEventHandler : DomainEventHandler<IdentityCreated>
{
    private readonly ILogger<IdentityCreatedEventHandler> _logger;

    public IdentityCreatedEventHandler(ILogger<IdentityCreatedEventHandler> logger)
    {
        _logger = logger;
    }

    public override Task Handle(IdentityCreated @event, CancellationToken ct)
    {
        _logger.LogInformation("Identity created event was handled");
        return Task.CompletedTask;
    }
}