using WebGames.Application.AppService.Interface;
using WebGames.Application.Request.Articles;
using WebGames.Application.Response.Articles;

namespace WebGames.Application.AppService;

public class ArticlesAppService : IArticlesAppService
{
    Task<(bool, DeleteArticleResponse)> IArticlesAppService.DeleteArticle(Guid Id)
    {
        throw new NotImplementedException();
    }

    Task<(bool, GetByIdResponse)> IArticlesAppService.GetById(Guid Id)
    {
        throw new NotImplementedException();
    }

    Task<(bool, GetByNameResponse)> IArticlesAppService.GetByName(string request)
    {
        throw new NotImplementedException();
    }

    Task<(bool, PatchArticleResponse)> IArticlesAppService.PatchArticle(PatchArticleRequest request)
    {
        throw new NotImplementedException();
    }

    Task<(bool, PostArticleResponse)> IArticlesAppService.PostArticle(PostArticleRequest request)
    {
        throw new NotImplementedException();
    }
}
