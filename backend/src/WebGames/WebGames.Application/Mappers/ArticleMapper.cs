using WebGames.Application.Response.Articles;
using WebGames.Domain.Entities;

namespace WebGames.Application.Mappers;

public static class ArticleMapper
{
    public static GetByIdResponse ToGetByIdResponse(Article article)
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

    public static PostArticleResponse ToPostResponse(Article article)
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

    public static PatchArticleResponse ToPatchResponse(Article article)
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

    public static DeleteArticleResponse ToDeleteResponse(Article article)
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
