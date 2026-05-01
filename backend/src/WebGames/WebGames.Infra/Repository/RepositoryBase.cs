using Microsoft.EntityFrameworkCore;
using WebGames.Domain.Entities;
using WebGames.Infra.Context;

namespace WebGames.Infra.Repository;

public abstract class RepositoryBase<TEntity>(WebGamesDbContext context)
    where TEntity : BaseEntity
{
    protected readonly WebGamesDbContext Context = context;
    protected readonly DbSet<TEntity> DbSet = context.Set<TEntity>();

    public async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        var now = DateTime.UtcNow;

        if (entity.Id == Guid.Empty)
            entity.Id = Guid.NewGuid();

        entity.CreateDate = now;
        entity.UpdateDate = now;

        await DbSet.AddAsync(entity, cancellationToken);
        await Context.SaveChangesAsync(cancellationToken);
    }

    public async Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await DbSet.AsNoTracking()
            .FirstOrDefaultAsync(entity => entity.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await DbSet.AsNoTracking()
            .OrderByDescending(entity => entity.CreateDate)
            .ToListAsync(cancellationToken);
    }

    public async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        entity.UpdateDate = DateTime.UtcNow;

        DbSet.Update(entity);
        await Context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var entity = await DbSet.FirstOrDefaultAsync(item => item.Id == id, cancellationToken);

        if (entity is null)
            return;

        DbSet.Remove(entity);
        await Context.SaveChangesAsync(cancellationToken);
    }
}
