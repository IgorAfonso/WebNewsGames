using WebGames.Domain.Entities;
using WebGames.Domain.Interface.Service;

namespace WebGames.Domain.Service;

public class ChampionshipDomainService : IChampionshipDomainService
{
    private const int TitleMaxLength = 200;
    private const int DescriptionMaxLength = 500;

    public async Task<(bool, string)> CreateChampionshipAsync(Championship request) => ValidateChampionship(request);
    public async Task<(bool, string)> UpdateChampionshipAsync(Championship request) => ValidateChampionship(request);
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

    private static (bool, string) ValidateChampionship(Championship request)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
            return (false, "The championship name is required.");

        if (request.Name.Length > TitleMaxLength)
            return (false, "The championship name cannot contain more than 200 characters.");

        if (string.IsNullOrWhiteSpace(request.Description))
            return (false, "The championship description is required.");

        if (request.Description.Length > DescriptionMaxLength)
            return (false, "The championship description cannot contain more than 500 characters.");

        if (string.IsNullOrWhiteSpace(request.System))
            return (false, "The championship system is required.");

        if (string.IsNullOrWhiteSpace(request.Place))
            return (false, "The championship place is required.");

        if (request.StartDate == default || request.EndDate == default)
            return (false, "The championship occurrence period is required.");

        if (request.EndDate < request.StartDate)
            return (false, "The championship end date cannot be earlier than the start date.");

        return (true, string.Empty);
    }
}
