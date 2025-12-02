using WebGames.Domain.Entities;
using WebGames.Domain.Interface.Service;

namespace WebGames.Domain.Service;

internal class ArticleService : IArticleDomainService
{
    public async Task<(bool, string)> CreateArticleAsync(Article request)
    {
        if (request.Title is null || request.Content is null)
            return (false, "Title and Content cannot be null.");

        return (true, string.Empty);
    }

    public async Task<(bool, string)> UpdateArticleAsync(Article request)
    {
        if (request.Title is null || request.Content is null)
            return (false, "Title and Content cannot be null.");

        return (true, string.Empty);
    }

    public async Task<(bool, string)> DeleteArticleAsync(Article request)
    {
        if (request.Id == Guid.Empty)
            return (false, "Invalid Article ID.");

        return (true, string.Empty);
    }

    public async Task<(bool, string)> GetArticleAsync(Article request)
    {
        if (request.Id == Guid.Empty)
            return (false, "Invalid Article ID.");

        return (true, string.Empty);
    }

    public async Task<(bool, string)> ListArticlesAsync()
    {
        return (true, string.Empty);
    }
}
