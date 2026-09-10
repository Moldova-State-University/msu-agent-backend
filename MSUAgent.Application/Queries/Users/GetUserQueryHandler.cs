using MediatR;
using MSUAgent.Application.Interfaces;

namespace MSUAgent.Application.Queries.Users;

public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserResponse?>
{
    private readonly IUserRepository _userRepository;

    public GetUserQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserResponse?> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(
            request.Id,
            cancellationToken);

        if (user is null)
        {
            return null;
        }

        return new UserResponse(
            user.Id,
            user.DisplayName,
            user.Email,
            user.Roles.Select(role => role.Name).ToList());
    }
}