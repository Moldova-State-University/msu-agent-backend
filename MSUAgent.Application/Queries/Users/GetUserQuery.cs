using MediatR;
using MSUAgent.Application.Models.Results;

namespace MSUAgent.Application.Queries.Users;
public record GetUserQuery(Guid Id) : IRequest<IResult<UserDto>>;
