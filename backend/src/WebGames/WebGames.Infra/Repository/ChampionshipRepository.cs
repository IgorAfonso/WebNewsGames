using WebGames.Domain.Entities;
using WebGames.Domain.Interface.Repository;
using WebGames.Infra.Context;

namespace WebGames.Infra.Repository;

public class ChampionshipRepository(WebGamesDbContext context)
    : RepositoryBase<Championship>(context), IChampionshipRepository
{
}
