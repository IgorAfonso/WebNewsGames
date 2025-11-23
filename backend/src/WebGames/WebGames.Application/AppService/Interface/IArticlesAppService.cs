using WebGames.Application.Request.Articles;
using WebGames.Application.Response.Articles;

namespace WebGames.Application.AppService.Interface;

public interface IArticlesAppService
{
    public Task<(bool, GetByIdResponse)> GetById(Guid Id);
    public Task<(bool, GetByNameResponse)> GetByName(string request);
    public Task<(bool, PostArticleResponse)> PostArticle(PostArticleRequest request);
    public Task<(bool, DeleteArticleResponse)> DeleteArticle(Guid Id);
    public Task<(bool, PatchArticleResponse)> PatchArticle(PatchArticleRequest request);
}
