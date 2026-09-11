namespace MSUAgent.Application.Interfaces;

public interface IUnitOfWork
{
    IUserRepository Users { get; }

    Task SaveChangesAsync(
        CancellationToken cancellationToken = default);
}