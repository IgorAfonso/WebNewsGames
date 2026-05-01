using WebGames.Application.Request.Championship;
using WebGames.Application.Request;
using WebGames.Application.Response;
using WebGames.Application.Response.Championship;

namespace WebGames.Application.AppService.Interface;

public interface IChampionshipAppService
{
    public Task<(bool, PagedResponse<GetByIdResponse>)> GetAll(PaginationRequest request);
    public Task<(bool, GetByIdResponse)> GetById(Guid Id);
    public Task<(bool, PostChampionshipResponse)> PostChamp(PostChampionshipRequest request);
    public Task<(bool, DeleteChampionshipResponse)> DeleteChamp(Guid Id);
    public Task<(bool, PatchChampionshipResponse)> PatchChamp(PatchChampionshipRequest request);
}
