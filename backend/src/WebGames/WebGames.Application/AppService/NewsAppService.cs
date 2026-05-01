using WebGames.Application.AppService.Interface;
using WebGames.Application.Request.News;
using WebGames.Application.Response.News;
using WebGames.Domain.Entities;
using WebGames.Domain.Interface.Repository;
using WebGames.Domain.Interface.Service;

namespace WebGames.Application.AppService;

public class NewsAppService(
    INewsRepository newsRepository,
    INewsDomainService newsDomainService) : INewsAppService
{
    public async Task<(bool, GetByIdResponse)> GetById(Guid Id)
    {
        var validation = await newsDomainService.GetNewsByIdAsync(Id);

        if (!validation.Item1)
            return (false, new GetByIdResponse());

        var news = await newsRepository.GetByIdAsync(Id);

        if (news is null)
            return (false, new GetByIdResponse());

        return (true, MapToGetByIdResponse(news));
    }

    public async Task<(bool, GetByNameResponse)> GetByName(string request)
    {
        if (string.IsNullOrWhiteSpace(request))
            return (false, new GetByNameResponse());

        var newsList = await newsRepository.GetAllAsync();
        var news = newsList.FirstOrDefault(item =>
            string.Equals(item.Title, request, StringComparison.OrdinalIgnoreCase));

        if (news is null)
            return (false, new GetByNameResponse());

        return (true, MapToGetByNameResponse(news));
    }

    public async Task<(bool, PostNewsResponse)> PostNews(PostNewsRequest request)
    {
        var news = new News
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
            PublishedAt = DateTime.UtcNow
        };

        var validation = await newsDomainService.CreateNewsAsync(news);

        if (!validation.Item1)
            return (false, new PostNewsResponse());

        await newsRepository.AddAsync(news);

        return (true, MapToPostResponse(news));
    }

    public async Task<(bool, DeleteNewsResponse)> DeleteNews(Guid Id)
    {
        var existingNews = await newsRepository.GetByIdAsync(Id);

        if (existingNews is null)
            return (false, new DeleteNewsResponse());

        var validation = await newsDomainService.DeleteNewsAsync(Id);

        if (!validation.Item1)
            return (false, new DeleteNewsResponse());

        await newsRepository.DeleteAsync(Id);

        return (true, MapToDeleteResponse(existingNews));
    }

    public async Task<(bool, PatchNewsResponse)> PatchNews(PatchNewsRequest request)
    {
        var existingNews = await newsRepository.GetByIdAsync(request.Id);

        if (existingNews is null)
            return (false, new PatchNewsResponse());

        existingNews.Title = request.Title ?? existingNews.Title;
        existingNews.Content = request.Content ?? existingNews.Content;
        existingNews.ImageBase64 = request.ImageBase64 ?? existingNews.ImageBase64;
        existingNews.ImageCaption = request.ImageCaption ?? existingNews.ImageCaption;
        existingNews.Content2 = request.Content2 ?? existingNews.Content2;
        existingNews.Image2Base64 = request.Image2Base64 ?? existingNews.Image2Base64;
        existingNews.Image2Caption = request.Image2Caption ?? existingNews.Image2Caption;
        existingNews.Content3 = request.Content3 ?? existingNews.Content3;
        existingNews.Image3Base64 = request.Image3Base64 ?? existingNews.Image3Base64;
        existingNews.Image3Caption = request.Image3Caption ?? existingNews.Image3Caption;

        var validation = await newsDomainService.UpdateNewsAsync(existingNews);

        if (!validation.Item1)
            return (false, new PatchNewsResponse());

        await newsRepository.UpdateAsync(existingNews);

        return (true, MapToPatchResponse(existingNews));
    }

    private static GetByIdResponse MapToGetByIdResponse(News news)
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

    private static GetByNameResponse MapToGetByNameResponse(News news)
    {
        return new GetByNameResponse
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

    private static PostNewsResponse MapToPostResponse(News news)
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

    private static PatchNewsResponse MapToPatchResponse(News news)
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

    private static DeleteNewsResponse MapToDeleteResponse(News news)
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
