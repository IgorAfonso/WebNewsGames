using WebGames.Application.AppService.Interface;
using WebGames.Application.Request.Articles;
using WebGames.Application.Response.Articles;
using WebGames.Domain.Entities;
using WebGames.Domain.Interface.Repository;
using WebGames.Domain.Interface.Service;

namespace WebGames.Application.AppService;

public class ArticlesAppService(
    IArticleRepository articleRepository,
    IArticleDomainService articleDomainService) : IArticlesAppService
{
    public async Task<(bool, DeleteArticleResponse)> DeleteArticle(Guid Id)
    {
        var existingArticle = await articleRepository.GetByIdAsync(Id);

        if (existingArticle is null)
            return (false, new DeleteArticleResponse());

        var validation = await articleDomainService.DeleteArticleAsync(existingArticle);

        if (!validation.Item1)
            return (false, new DeleteArticleResponse());

        await articleRepository.DeleteAsync(Id);

        return (true, MapToDeleteResponse(existingArticle));
    }

    public async Task<(bool, GetByIdResponse)> GetById(Guid Id)
    {
        var validation = await articleDomainService.GetArticleAsync(new Article { Id = Id });

        if (!validation.Item1)
            return (false, new GetByIdResponse());

        var article = await articleRepository.GetByIdAsync(Id);

        if (article is null)
            return (false, new GetByIdResponse());

        return (true, MapToGetByIdResponse(article));
    }

    public async Task<(bool, GetByNameResponse)> GetByName(string request)
    {
        if (string.IsNullOrWhiteSpace(request))
            return (false, new GetByNameResponse());

        var articles = await articleRepository.GetAllAsync();
        var article = articles.FirstOrDefault(item =>
            string.Equals(item.Title, request, StringComparison.OrdinalIgnoreCase));

        if (article is null)
            return (false, new GetByNameResponse());

        return (true, MapToGetByNameResponse(article));
    }

    public async Task<(bool, PatchArticleResponse)> PatchArticle(PatchArticleRequest request)
    {
        var existingArticle = await articleRepository.GetByIdAsync(request.Id);

        if (existingArticle is null)
            return (false, new PatchArticleResponse());

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
            return (false, new PatchArticleResponse());

        await articleRepository.UpdateAsync(existingArticle);

        return (true, MapToPatchResponse(existingArticle));
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
            return (false, new PostArticleResponse());

        await articleRepository.AddAsync(article);

        return (true, MapToPostResponse(article));
    }

    private static GetByIdResponse MapToGetByIdResponse(Article article)
    {
        return new GetByIdResponse
        {
            Id = article.Id,
            Title = article.Title,
            Content = article.Content,
            ImageBase64 = article.ImageBase64,
            ImageCaption = article.ImageCaption,
            Content2 = article.Content2,
            Image2Base64 = article.Image2Base64,
            Image2Caption = article.Image2Caption,
            Content3 = article.Content3,
            Image3Base64 = article.Image3Base64,
            Image3Caption = article.Image3Caption
        };
    }

    private static GetByNameResponse MapToGetByNameResponse(Article article)
    {
        return new GetByNameResponse
        {
            Id = article.Id,
            Title = article.Title,
            Content = article.Content,
            ImageBase64 = article.ImageBase64,
            ImageCaption = article.ImageCaption,
            Content2 = article.Content2,
            Image2Base64 = article.Image2Base64,
            Image2Caption = article.Image2Caption,
            Content3 = article.Content3,
            Image3Base64 = article.Image3Base64,
            Image3Caption = article.Image3Caption
        };
    }

    private static PostArticleResponse MapToPostResponse(Article article)
    {
        return new PostArticleResponse
        {
            Id = article.Id,
            Title = article.Title,
            Content = article.Content,
            ImageBase64 = article.ImageBase64,
            ImageCaption = article.ImageCaption,
            Content2 = article.Content2,
            Image2Base64 = article.Image2Base64,
            Image2Caption = article.Image2Caption,
            Content3 = article.Content3,
            Image3Base64 = article.Image3Base64,
            Image3Caption = article.Image3Caption
        };
    }

    private static PatchArticleResponse MapToPatchResponse(Article article)
    {
        return new PatchArticleResponse
        {
            Id = article.Id,
            Title = article.Title,
            Content = article.Content,
            ImageBase64 = article.ImageBase64,
            ImageCaption = article.ImageCaption,
            Content2 = article.Content2,
            Image2Base64 = article.Image2Base64,
            Image2Caption = article.Image2Caption,
            Content3 = article.Content3,
            Image3Base64 = article.Image3Base64,
            Image3Caption = article.Image3Caption
        };
    }

    private static DeleteArticleResponse MapToDeleteResponse(Article article)
    {
        return new DeleteArticleResponse
        {
            Id = article.Id,
            Title = article.Title,
            Content = article.Content,
            ImageBase64 = article.ImageBase64,
            ImageCaption = article.ImageCaption,
            Content2 = article.Content2,
            Image2Base64 = article.Image2Base64,
            Image2Caption = article.Image2Caption,
            Content3 = article.Content3,
            Image3Base64 = article.Image3Base64,
            Image3Caption = article.Image3Caption
        };
    }
}
