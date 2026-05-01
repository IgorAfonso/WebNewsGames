using WebGames.Application.AppService.Interface;
using WebGames.Application.Auth;
using WebGames.Application.Mappers;
using WebGames.Application.Request;
using WebGames.Application.Request.News;
using WebGames.Application.Response;
using WebGames.Application.Response.News;
using WebGames.Domain.Entities;
using WebGames.Domain.Interface.Repository;
using WebGames.Domain.Interface.Service;

namespace WebGames.Application.AppService;

public class NewsAppService(
    INewsRepository newsRepository,
    INewsDomainService newsDomainService,
    ICurrentUserService currentUserService) : INewsAppService
{
    public async Task<(bool, PagedResponse<GetByIdResponse>)> GetAll(PaginationRequest request)
    {
        var pagination = PaginationAppService.Validate(request);

        if (!pagination.Success)
            return (false, new PagedResponse<GetByIdResponse> { ErrorMessage = pagination.ErrorMessage });

        var newsList = await newsRepository.GetAllAsync();
        var totalItems = newsList.Count;
        var items = newsList
            .Skip((pagination.Page - 1) * pagination.PageSize)
            .Take(pagination.PageSize)
            .Select(NewsMapper.ToGetByIdResponse)
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

    public async Task<(bool, GetByIdResponse)> GetById(Guid Id)
    {
        var validation = await newsDomainService.GetNewsByIdAsync(Id);

        if (!validation.Item1)
            return (false, new GetByIdResponse { ErrorMessage = validation.Item2 });

        var news = await newsRepository.GetByIdAsync(Id);

        if (news is null)
            return (false, new GetByIdResponse { ErrorMessage = "News not found." });

        return (true, NewsMapper.ToGetByIdResponse(news));
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
            PublishedAt = DateTime.UtcNow,
            AuthorUserId = currentUserService.UserId,
            AuthorName = currentUserService.UserName
        };

        var validation = await newsDomainService.CreateNewsAsync(news);

        if (!validation.Item1)
            return (false, new PostNewsResponse { ErrorMessage = validation.Item2 });

        await newsRepository.AddAsync(news);
        return (true, NewsMapper.ToPostResponse(news));
    }

    public async Task<(bool, DeleteNewsResponse)> DeleteNews(Guid Id)
    {
        var existingNews = await newsRepository.GetByIdAsync(Id);

        if (existingNews is null)
            return (false, new DeleteNewsResponse { ErrorMessage = "News not found." });

        var validation = await newsDomainService.DeleteNewsAsync(Id);

        if (!validation.Item1)
            return (false, new DeleteNewsResponse { ErrorMessage = validation.Item2 });

        await newsRepository.DeleteAsync(Id);
        return (true, NewsMapper.ToDeleteResponse(existingNews));
    }

    public async Task<(bool, PatchNewsResponse)> PatchNews(PatchNewsRequest request)
    {
        var existingNews = await newsRepository.GetByIdAsync(request.Id);

        if (existingNews is null)
            return (false, new PatchNewsResponse { ErrorMessage = "News not found." });

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
            return (false, new PatchNewsResponse { ErrorMessage = validation.Item2 });

        await newsRepository.UpdateAsync(existingNews);
        return (true, NewsMapper.ToPatchResponse(existingNews));
    }
}
