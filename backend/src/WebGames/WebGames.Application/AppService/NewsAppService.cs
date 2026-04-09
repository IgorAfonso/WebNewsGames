using WebGames.Application.AppService.Interface;
using WebGames.Application.Request.News;
using WebGames.Application.Response.News;

namespace WebGames.Application.AppService;

public class NewsAppService : INewsAppService
{
    Task<(bool, GetByIdResponse)> INewsAppService.GetById(Guid Id)
    {
        throw new NotImplementedException();
    }

    Task<(bool, GetByNameResponse)> INewsAppService.GetByName(string request)
    {
        throw new NotImplementedException();
    }

    Task<(bool, PostNewsResponse)> INewsAppService.PostNews(PostNewsRequest request)
    {
        throw new NotImplementedException();
    }

    Task<(bool, DeleteNewsResponse)> INewsAppService.DeleteNews(Guid Id)
    {
        throw new NotImplementedException();
    }

    Task<(bool, PatchNewsResponse)> INewsAppService.PatchNews(PatchNewsRequest request)
    {
        throw new NotImplementedException();
    }
}
