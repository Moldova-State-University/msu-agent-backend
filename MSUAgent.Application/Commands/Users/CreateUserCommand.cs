using MediatR;  
using MSUAgent.Application.Models.Results;

namespace MSUAgent.Application.Commands.Users;

public record CreateUserCommand(string DisplayName, string Email) : IRequest<IResult<Guid>>;  

