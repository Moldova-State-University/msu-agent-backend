using MediatR;
using Microsoft.AspNetCore.Mvc;
using MSUAgent.Identity.Application.Commands.CreateIdentity;

namespace MSUAgent.Identity.Infrastructure.Rest.Controllers.Controllers;

[ApiController]
[Route("[controller]")]
public class IdentityController : ControllerBase
{
    private readonly IMediator _mediator;

    public IdentityController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public void Get()
    {
        var command = new CreateIdentityCommand();
        
        _ = _mediator.Send(command);
    }
}