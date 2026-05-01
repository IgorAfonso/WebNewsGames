using WebGames.Domain.Entities;
using WebGames.Domain.Interface.Service;

namespace WebGames.Domain.Service;

public class ChampionshipDomainService : IChampionshipDomainService
{
    private const int TitleMaxLength = 200;

    public async Task<(bool, string)> CreateChampionshipAsync(Championship request)
    {
        if (request.Name is null || request.Description is null)
            return (false, "Name and Description cannot be null.");

        if (request.Name.Length > TitleMaxLength)
            return (false, "Name cannot exceed 200 characters.");

        return (true, string.Empty);
    }

    public async Task<(bool, string)> UpdateChampionshipAsync(Championship request)
    {
        if (request.Name is null || request.Description is null)
            return (false, "Name and Description cannot be null.");

        if (request.Name.Length > TitleMaxLength)
            return (false, "Name cannot exceed 200 characters.");

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
