using MediatR;
using MSUAgent.Application.Models.Results;

namespace MSUAgent.Application.Queries.UserRoles.GetUserRoles;

public record GetUserRolesQuery() : IRequest<IResult<List<UserRoleDto>>>;