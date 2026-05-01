using WebGames.Domain.Entities;

namespace WebGames.Domain.Interface.Repository;

public interface IArticleRepository
{
    Task AddAsync(Article article, CancellationToken cancellationToken = default);
    Task<Article?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Article>> GetAllAsync(CancellationToken cancellationToken = default);
    Task UpdateAsync(Article article, CancellationToken cancellationToken = default);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}
