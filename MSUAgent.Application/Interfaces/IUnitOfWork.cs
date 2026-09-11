namespace MSUAgent.Application.Interfaces;

public interface IUnitOfWork
{
    IUserRepository Users { get; }
    IUserRoleRepository UserRoles { get; }

    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}