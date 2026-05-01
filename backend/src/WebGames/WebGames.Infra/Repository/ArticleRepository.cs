using WebGames.Domain.Entities;
using WebGames.Domain.Interface.Repository;
using WebGames.Infra.Context;

namespace WebGames.Infra.Repository;

public class ArticleRepository(WebGamesDbContext context)
    : RepositoryBase<Article>(context), IArticleRepository
{
}
