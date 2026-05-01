using WebGames.Domain.Entities;

namespace WebGames.Domain.Interface.Repository;

public interface INewsRepository
{
    Task AddAsync(News news, CancellationToken cancellationToken = default);
    Task<News?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<News>> GetAllAsync(CancellationToken cancellationToken = default);
    Task UpdateAsync(News news, CancellationToken cancellationToken = default);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}
