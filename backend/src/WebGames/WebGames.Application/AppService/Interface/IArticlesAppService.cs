using WebGames.Application.Request.Articles;
using WebGames.Application.Request;
using WebGames.Application.Response;
using WebGames.Application.Response.Articles;

namespace WebGames.Application.AppService.Interface;

public interface IArticlesAppService
{
    public Task<(bool, PagedResponse<GetByIdResponse>)> GetAll(PaginationRequest request);
    public Task<(bool, GetByIdResponse)> GetById(Guid Id);
    public Task<(bool, PostArticleResponse)> PostArticle(PostArticleRequest request);
    public Task<(bool, DeleteArticleResponse)> DeleteArticle(Guid Id);
    public Task<(bool, PatchArticleResponse)> PatchArticle(PatchArticleRequest request);
}
