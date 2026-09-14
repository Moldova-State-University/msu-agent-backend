
namespace MSUAgent.Application.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IEnumerable<T>> GetListAsync(CancellationToken cancellationToken = default);
    }
}