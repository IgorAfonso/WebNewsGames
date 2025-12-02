using WebGames.Domain.Entities;

namespace WebGames.Domain.Interface.Service
{
    public interface IChampionshipDomainService
    {
        public Task<(bool, string)> CreateChampionshipAsync(Championship request);
        public Task<(bool, string)> UpdateChampionshipAsync(Championship request);
        public Task<(bool, string)> DeleteChampionshipAsync(Guid championshipId);
        public Task<(bool, string)> GetChampionshipByIdAsync(Guid championshipId);
    }
}
