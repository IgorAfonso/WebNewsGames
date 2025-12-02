using WebGames.Domain.Entities;
using WebGames.Domain.Interface.Service;

namespace WebGames.Domain.Service;

internal class NewsService : INewsDomainService
{
    public async Task<(bool, string)> CreateNewsAsync(News request)
    {
        if(request.Title is null || request.Content is null)
            return (false, "Title and Content cannot be null.");

        return (true, "News created successfully.");
    }

    public async Task<(bool, string)> GetNewsByIdAsync(Guid id)
    {
        if(id == Guid.Empty)
            return (false, "Invalid news ID.");

        return (true, "News retrieved successfully.");
    }

    public async Task<(bool, string)> UpdateNewsAsync(News request)
    {
        if(request.Id <= 0)
            return (false, "Invalid news ID.");

        return (true, "News updated successfully.");
    }

    public async Task<(bool, string)> DeleteNewsAsync(Guid id)
    {
        if(id == Guid.Empty)
            return (false, "Invalid news ID.");

        return (true, "News deleted successfully.");
    }
}
