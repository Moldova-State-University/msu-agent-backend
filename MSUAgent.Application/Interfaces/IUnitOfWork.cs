namespace MSUAgent.Application.Interfaces;

public interface IUnitOfWork
{
    IUserRepository Users { get; }

    Task<int> SaveChangesAsync(
        CancellationToken cancellationToken = default);
}