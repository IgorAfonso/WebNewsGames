using WebGames.Domain.Entities;

namespace WebGames.Domain.Interface.Repository;

public interface IChampionshipRepository
{
    Task AddAsync(Championship championship, CancellationToken cancellationToken = default);
    Task<Championship?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Championship>> GetAllAsync(CancellationToken cancellationToken = default);
    Task UpdateAsync(Championship championship, CancellationToken cancellationToken = default);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}
