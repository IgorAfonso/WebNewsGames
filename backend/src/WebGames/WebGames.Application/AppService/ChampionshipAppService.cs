using WebGames.Application.AppService.Interface;
using WebGames.Application.Request.Championship;
using WebGames.Application.Response.Championship;

namespace WebGames.Application.AppService;

public class ChampionshipAppService : IChampionshipAppService
{
    Task<(bool, DeleteChampionshipResponse)> IChampionshipAppService.DeleteChamp(Guid Id)
    {
        throw new NotImplementedException();
    }

    Task<(bool, GetByIdResponse)> IChampionshipAppService.GetById(Guid Id)
    {
        throw new NotImplementedException();
    }

    Task<(bool, GetByNameResponse)> IChampionshipAppService.GetByName(string request)
    {
        throw new NotImplementedException();
    }

    Task<(bool, PatchChampionshipResponse)> IChampionshipAppService.PatchChamp(PatchChampionshipRequest request)
    {
        throw new NotImplementedException();
    }

    Task<(bool, PostChampionshipResponse)> IChampionshipAppService.PostChamp(PostChampionshipRequest request)
    {
        throw new NotImplementedException();
    }
}
