using MediatR;
using Microsoft.Extensions.Logging;
using MSUAgent.Identity.Application.Abstractions;

using IdentityAgregate = MSUAgent.Identity.Domain.Agregates.Identity;

namespace MSUAgent.Identity.Application.Commands.CreateIdentity;

public class CreateIdentityHandler : IRequestHandler<CreateIdentityCommand, IdentityDto>
{
    private readonly ILogger<CreateIdentityHandler> _logger;
    private readonly IDomainEventDispatcher _domainEventDispatcher;

    public CreateIdentityHandler(ILogger<CreateIdentityHandler> logger, IDomainEventDispatcher domainEventDispatcher)
    {
        _logger = logger;
        _domainEventDispatcher = domainEventDispatcher;
    }

    public Task<IdentityDto> Handle(CreateIdentityCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Create identity command was handled");

        var identity = IdentityAgregate.Create();

        _domainEventDispatcher.Dispatch(identity.DomainEvents, cancellationToken);

        return Task.FromResult(new IdentityDto());
    }
}