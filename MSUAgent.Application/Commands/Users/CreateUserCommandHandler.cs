using MediatR;
using MSUAgent.Application.Interfaces;
using MSUAgent.Application.Models.Results;
using MSUAgent.Domain.Entities;

namespace MSUAgent.Application.Commands.Users;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, IResult<Guid>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateUserCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IResult<Guid>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var memberRole = await _unitOfWork.UserRoles.GetByNameAsync("Member", cancellationToken);

        if (memberRole is null)
        {
            return ResultExtensions.Failure<Guid>(
                ErrorType.NotFound,
                "Member role not found");
        }

        var user = new User
        {
            Id = Guid.NewGuid(),
            DisplayName = request.DisplayName,
            Email = request.Email,
            Roles = [memberRole]
        };

        await _unitOfWork.Users.AddAsync(user, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return user.Id.Success();
    }
}