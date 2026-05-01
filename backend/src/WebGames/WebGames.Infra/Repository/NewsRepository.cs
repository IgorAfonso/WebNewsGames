using WebGames.Domain.Entities;
using WebGames.Domain.Interface.Repository;
using WebGames.Infra.Context;

namespace WebGames.Infra.Repository;

public class NewsRepository(WebGamesDbContext context)
    : RepositoryBase<News>(context), INewsRepository
{
}
