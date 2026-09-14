using MediatR;
using MSUAgent.Application.Interfaces;
using MSUAgent.Application.Models.Results;

namespace MSUAgent.Application.Queries.UserRoles.GetUserRoles;

public class GetUserRolesQueryHandler : IRequestHandler<GetUserRolesQuery, IResult<List<UserRoleDto>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetUserRolesQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IResult<List<UserRoleDto>>> Handle(GetUserRolesQuery request, CancellationToken cancellationToken)
    {
        var userRoles = await _unitOfWork.UserRoles.GetListAsync(cancellationToken);

        if (!userRoles.Any())
        {
            return ResultExtensions.Failure<List<UserRoleDto>>(ErrorType.NotFound, "User roles not found");
        }

        return userRoles.Select(r => new UserRoleDto(r.Id, r.Name)).ToList().Success();
    }
}