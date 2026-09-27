using Microsoft.Extensions.Logging;
using MSUAgent.Identity.Application.Abstractions;
using MSUAgent.Identity.Domain.Events;

namespace MSUAgent.Identity.Application.EventHandlers;

public class SampleEventHanlder : DomainEventHandler<SampleEvent>
{
    private readonly ILogger<SampleEventHanlder> _logger;

    public SampleEventHanlder(ILogger<SampleEventHanlder> logger)
    {
        _logger = logger;
    }

    public override Task Handle(SampleEvent @event, CancellationToken ct)
    {
        _logger.LogInformation("Sample event event was handled");
        return Task.CompletedTask;
    }
}