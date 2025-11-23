using WebGames.Application.Request.News;
using WebGames.Application.Response.News;

namespace WebGames.Application.AppService.Interface;

public interface INewsAppService
{
    public Task<(bool, GetByIdResponse)> GetById(Guid Id);
    public Task<(bool, GetByNameResponse)> GetByName(string request);
    public Task<(bool, PostNewsResponse)> PostNews(PostNewsRequest request);
    public Task<(bool, DeleteNewsResponse)> DeleteNews(Guid Id);
    public Task<(bool, PatchNewsResponse)> PatchNews(PatchNewsRequest request);
}
