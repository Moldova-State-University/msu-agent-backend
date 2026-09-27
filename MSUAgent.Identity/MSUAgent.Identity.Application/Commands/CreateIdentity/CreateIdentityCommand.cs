using MediatR;

namespace MSUAgent.Identity.Application.Commands.CreateIdentity;

public class CreateIdentityCommand : IRequest<IdentityDto> { }