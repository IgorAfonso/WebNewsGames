using WebGames.Domain.Entities;
using WebGames.Domain.Interface.Repository;

namespace WebGames.Domain.Interface.Service
{
    public interface IArticleDomainService
    {
        public Task<(bool, string)> CreateArticleAsync(Article request);
        public Task<(bool, string)> UpdateArticleAsync(Article request);
        public Task<(bool, string)> DeleteArticleAsync(Article request);
        public Task<(bool, string)> GetArticleAsync(Article request);
        public Task<(bool, string)> ListArticlesAsync();
    }
}
