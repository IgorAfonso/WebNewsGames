using WebGames.Application.Request.Championship;
using WebGames.Application.Response.Championship;

namespace WebGames.Application.AppService.Interface;

public interface IChampionshipAppService
{
    public Task<(bool, GetByNameResponse)> GetByName(string request);
    public Task<(bool, GetByIdResponse)> GetById(Guid Id);
    public Task<(bool, PostChampionshipResponse)> PostChamp(PostChampionshipRequest request);
    public Task<(bool, DeleteChampionshipResponse)> DeleteChamp(Guid Id);
    public Task<(bool, PatchChampionshipResponse)> PatchChamp(PatchChampionshipRequest request);
}