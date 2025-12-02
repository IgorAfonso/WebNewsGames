using WebGames.Domain.Entities;

namespace WebGames.Domain.Interface.Service;

public interface INewsDomainService
{
    public Task<(bool, string)> CreateNewsAsync(News request);
    public Task<(bool, string)> GetNewsByIdAsync(Guid id);
    public Task<(bool, string)> UpdateNewsAsync(News request);
    public Task<(bool, string)> DeleteNewsAsync(Guid id);
}
