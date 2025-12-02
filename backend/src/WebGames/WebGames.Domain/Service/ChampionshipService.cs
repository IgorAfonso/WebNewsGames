using WebGames.Domain.Entities;
using WebGames.Domain.Interface.Service;

namespace WebGames.Domain.Service;

internal class ChampionshipService : IChampionshipDomainService
{
    public async Task<(bool, string)> CreateChampionshipAsync(Championship request)
    {
        if (request.Name is null || request.Description is null)
            return (false, "Name and Description cannot be null.");

        return (true, string.Empty);
    }

    public async Task<(bool, string)> UpdateChampionshipAsync(Championship request)
    {
        if (request.Name is null || request.Description is null)
            return (false, "Name and Description cannot be null.");

        return (true, string.Empty);
    }

    public async Task<(bool, string)> DeleteChampionshipAsync(Guid championshipId)
    {
        if (championshipId == Guid.Empty)
            return (false, "Invalid Championship ID.");

        return (true, string.Empty);
    }

    public async Task<(bool, string)> GetChampionshipByIdAsync(Guid championshipId)
    {
        if (championshipId == Guid.Empty)
            return (false, "Invalid Championship ID.");

        return (true, string.Empty);
    }
}
