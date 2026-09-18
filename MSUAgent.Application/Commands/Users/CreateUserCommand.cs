using MediatR;  
using MSUAgent.Application.Models.Results;
using MSUAgent.Application.Queries.Users;

namespace MSUAgent.Application.Commands.Users;

public record CreateUserCommand(string DisplayName, string Email) : IRequest<IResult<UserDto>>;  

