using WebGames.Application.AppService.Interface;
using WebGames.Application.Mappers;
using WebGames.Application.Request;
using WebGames.Application.Request.Articles;
using WebGames.Application.Response;
using WebGames.Application.Response.Articles;
using WebGames.Domain.Entities;
using WebGames.Domain.Interface.Repository;
using WebGames.Domain.Interface.Service;

namespace WebGames.Application.AppService;

public class ArticlesAppService(
    IArticleRepository articleRepository,
    IArticleDomainService articleDomainService) : IArticlesAppService
{
    public async Task<(bool, PagedResponse<GetByIdResponse>)> GetAll(PaginationRequest request)
    {
        var pagination = PaginationAppService.Validate(request);

        if (!pagination.Success)
            return (false, new PagedResponse<GetByIdResponse> { ErrorMessage = pagination.ErrorMessage });

        var articles = await articleRepository.GetAllAsync();
        var totalItems = articles.Count;
        var items = articles
            .Skip((pagination.Page - 1) * pagination.PageSize)
            .Take(pagination.PageSize)
            .Select(ArticleMapper.ToGetByIdResponse)
            .ToList();

        return (true, new PagedResponse<GetByIdResponse>
        {
            Items = items,
            Page = pagination.Page,
            PageSize = pagination.PageSize,
            TotalItems = totalItems,
            TotalPages = (int)Math.Ceiling(totalItems / (double)pagination.PageSize)
        });
    }

    public async Task<(bool, DeleteArticleResponse)> DeleteArticle(Guid Id)
    {
        var existingArticle = await articleRepository.GetByIdAsync(Id);

        if (existingArticle is null)
            return (false, new DeleteArticleResponse { ErrorMessage = "Article not found." });

        var validation = await articleDomainService.DeleteArticleAsync(existingArticle);

        if (!validation.Item1)
            return (false, new DeleteArticleResponse { ErrorMessage = validation.Item2 });

        await articleRepository.DeleteAsync(Id);
        return (true, ArticleMapper.ToDeleteResponse(existingArticle));
    }

    public async Task<(bool, GetByIdResponse)> GetById(Guid Id)
    {
        var validation = await articleDomainService.GetArticleAsync(new Article { Id = Id });

        if (!validation.Item1)
            return (false, new GetByIdResponse { ErrorMessage = validation.Item2 });

        var article = await articleRepository.GetByIdAsync(Id);

        if (article is null)
            return (false, new GetByIdResponse { ErrorMessage = "Article not found." });

        return (true, ArticleMapper.ToGetByIdResponse(article));
    }

    public async Task<(bool, PatchArticleResponse)> PatchArticle(PatchArticleRequest request)
    {
        var existingArticle = await articleRepository.GetByIdAsync(request.Id);

        if (existingArticle is null)
            return (false, new PatchArticleResponse { ErrorMessage = "Article not found." });

        existingArticle.Title = request.Title ?? existingArticle.Title;
        existingArticle.Content = request.Content ?? existingArticle.Content;
        existingArticle.ImageBase64 = request.ImageBase64 ?? existingArticle.ImageBase64;
        existingArticle.ImageCaption = request.ImageCaption ?? existingArticle.ImageCaption;
        existingArticle.Content2 = request.Content2 ?? existingArticle.Content2;
        existingArticle.Image2Base64 = request.Image2Base64 ?? existingArticle.Image2Base64;
        existingArticle.Image2Caption = request.Image2Caption ?? existingArticle.Image2Caption;
        existingArticle.Content3 = request.Content3 ?? existingArticle.Content3;
        existingArticle.Image3Base64 = request.Image3Base64 ?? existingArticle.Image3Base64;
        existingArticle.Image3Caption = request.Image3Caption ?? existingArticle.Image3Caption;

        var validation = await articleDomainService.UpdateArticleAsync(existingArticle);

        if (!validation.Item1)
            return (false, new PatchArticleResponse { ErrorMessage = validation.Item2 });

        await articleRepository.UpdateAsync(existingArticle);

        return (true, ArticleMapper.ToPatchResponse(existingArticle));
    }

    public async Task<(bool, PostArticleResponse)> PostArticle(PostArticleRequest request)
    {
        var article = new Article
        {
            Title = request.Title,
            Content = request.Content,
            ImageBase64 = request.ImageBase64,
            ImageCaption = request.ImageCaption,
            Content2 = request.Content2,
            Image2Base64 = request.Image2Base64,
            Image2Caption = request.Image2Caption,
            Content3 = request.Content3,
            Image3Base64 = request.Image3Base64,
            Image3Caption = request.Image3Caption,
            PublishedDate = DateTime.UtcNow
        };

        var validation = await articleDomainService.CreateArticleAsync(article);

        if (!validation.Item1)
            return (false, new PostArticleResponse { ErrorMessage = validation.Item2 });

        await articleRepository.AddAsync(article);
        return (true, ArticleMapper.ToPostResponse(article));
    }
}
