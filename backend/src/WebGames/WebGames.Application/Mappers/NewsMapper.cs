using WebGames.Application.Response.News;
using WebGames.Domain.Entities;

namespace WebGames.Application.Mappers;

public static class NewsMapper
{
    public static GetByIdResponse ToGetByIdResponse(News news)
    {
        return new GetByIdResponse
        {
            Id = news.Id,
            Title = news.Title,
            Content = news.Content,
            ImageBase64 = news.ImageBase64,
            ImageCaption = news.ImageCaption,
            Content2 = news.Content2,
            Image2Base64 = news.Image2Base64,
            Image2Caption = news.Image2Caption,
            Content3 = news.Content3,
            Image3Base64 = news.Image3Base64,
            Image3Caption = news.Image3Caption
        };
    }

    public static PostNewsResponse ToPostResponse(News news)
    {
        return new PostNewsResponse
        {
            Id = news.Id,
            Title = news.Title,
            Content = news.Content,
            ImageBase64 = news.ImageBase64,
            ImageCaption = news.ImageCaption,
            Content2 = news.Content2,
            Image2Base64 = news.Image2Base64,
            Image2Caption = news.Image2Caption,
            Content3 = news.Content3,
            Image3Base64 = news.Image3Base64,
            Image3Caption = news.Image3Caption
        };
    }

    public static PatchNewsResponse ToPatchResponse(News news)
    {
        return new PatchNewsResponse
        {
            Id = news.Id,
            Title = news.Title,
            Content = news.Content,
            ImageBase64 = news.ImageBase64,
            ImageCaption = news.ImageCaption,
            Content2 = news.Content2,
            Image2Base64 = news.Image2Base64,
            Image2Caption = news.Image2Caption,
            Content3 = news.Content3,
            Image3Base64 = news.Image3Base64,
            Image3Caption = news.Image3Caption
        };
    }

    public static DeleteNewsResponse ToDeleteResponse(News news)
    {
        return new DeleteNewsResponse
        {
            Id = news.Id,
            Title = news.Title,
            Content = news.Content,
            ImageBase64 = news.ImageBase64,
            ImageCaption = news.ImageCaption,
            Content2 = news.Content2,
            Image2Base64 = news.Image2Base64,
            Image2Caption = news.Image2Caption,
            Content3 = news.Content3,
            Image3Base64 = news.Image3Base64,
            Image3Caption = news.Image3Caption
        };
    }
}
