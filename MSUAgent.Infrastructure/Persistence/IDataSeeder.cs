namespace MSUAgent.Infrastructure.Persistence;

public interface IDataSeeder
{
    Task SeedAsync(CancellationToken cancel);
}