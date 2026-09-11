using MediatR;
using MSUAgent.Application.Interfaces;
using MSUAgent.Application.Models.Results;

namespace MSUAgent.Application.Queries.Users;

public class GetUserQueryHandler : IRequestHandler<GetUserQuery, IResult<UserDto>>
{
    private readonly IUserRepository _userRepository;

    public GetUserQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<IResult<UserDto>> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(
            request.Id,
            cancellationToken);

        if (user is null)
        {
            return ResultExtensions.Failure<UserDto>(
                ErrorType.NotFound,
                "User not found");
        }

        var userDto = new UserDto(
            user.Id,
            user.DisplayName,
            user.Email,
            [.. user.Roles.Select(role => role.Name)]);

        return userDto.Success();
    }
}