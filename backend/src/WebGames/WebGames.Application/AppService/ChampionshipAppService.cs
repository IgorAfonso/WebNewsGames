using WebGames.Application.AppService.Interface;
using WebGames.Application.Request.Championship;
using WebGames.Application.Response.Championship;
using WebGames.Domain.Entities;
using WebGames.Domain.Interface.Repository;
using WebGames.Domain.Interface.Service;

namespace WebGames.Application.AppService;

public class ChampionshipAppService(
    IChampionshipRepository championshipRepository,
    IChampionshipDomainService championshipDomainService) : IChampionshipAppService
{
    public async Task<(bool, DeleteChampionshipResponse)> DeleteChamp(Guid Id)
    {
        var existingChampionship = await championshipRepository.GetByIdAsync(Id);

        if (existingChampionship is null)
            return (false, new DeleteChampionshipResponse());

        var validation = await championshipDomainService.DeleteChampionshipAsync(Id);

        if (!validation.Item1)
            return (false, new DeleteChampionshipResponse());

        await championshipRepository.DeleteAsync(Id);

        return (true, MapToDeleteResponse(existingChampionship));
    }

    public async Task<(bool, GetByIdResponse)> GetById(Guid Id)
    {
        var validation = await championshipDomainService.GetChampionshipByIdAsync(Id);

        if (!validation.Item1)
            return (false, new GetByIdResponse());

        var championship = await championshipRepository.GetByIdAsync(Id);

        if (championship is null)
            return (false, new GetByIdResponse());

        return (true, MapToGetByIdResponse(championship));
    }

    public async Task<(bool, GetByNameResponse)> GetByName(string request)
    {
        if (string.IsNullOrWhiteSpace(request))
            return (false, new GetByNameResponse());

        var championships = await championshipRepository.GetAllAsync();
        var championship = championships.FirstOrDefault(item =>
            string.Equals(item.Name, request, StringComparison.OrdinalIgnoreCase));

        if (championship is null)
            return (false, new GetByNameResponse());

        return (true, MapToGetByNameResponse(championship));
    }

    public async Task<(bool, PatchChampionshipResponse)> PatchChamp(PatchChampionshipRequest request)
    {
        var existingChampionship = await championshipRepository.GetByIdAsync(request.ChampId);

        if (existingChampionship is null)
            return (false, new PatchChampionshipResponse());

        existingChampionship.Name = request.ChampionshipName ?? existingChampionship.Name;
        existingChampionship.Description = request.ChampionshipDescription ?? existingChampionship.Description;
        existingChampionship.StartDate = request.ChampDate ?? existingChampionship.StartDate;
        existingChampionship.EndDate = request.RegistrationDeadLine ?? existingChampionship.EndDate;

        var validation = await championshipDomainService.UpdateChampionshipAsync(existingChampionship);

        if (!validation.Item1)
            return (false, new PatchChampionshipResponse());

        await championshipRepository.UpdateAsync(existingChampionship);

        return (true, MapToPatchResponse(existingChampionship));
    }

    public async Task<(bool, PostChampionshipResponse)> PostChamp(PostChampionshipRequest request)
    {
        var championship = new Championship
        {
            Name = request.ChampionshipName,
            Description = request.ChampionshipDescription,
            StartDate = request.ChampDate ?? DateTime.UtcNow,
            EndDate = request.RegistrationDeadLine ?? DateTime.UtcNow
        };

        var validation = await championshipDomainService.CreateChampionshipAsync(championship);

        if (!validation.Item1)
            return (false, new PostChampionshipResponse());

        await championshipRepository.AddAsync(championship);

        return (true, MapToPostResponse(championship));
    }

    private static GetByIdResponse MapToGetByIdResponse(Championship championship)
    {
        return new GetByIdResponse
        {
            ChampId = championship.Id,
            ChampionshipName = championship.Name,
            ChampionshipDescription = championship.Description,
            RegistrationDeadLine = championship.EndDate,
            ChampDate = championship.StartDate
        };
    }

    private static GetByNameResponse MapToGetByNameResponse(Championship championship)
    {
        return new GetByNameResponse
        {
            ChampId = championship.Id,
            ChampionshipName = championship.Name,
            ChampionshipDescription = championship.Description,
            RegistrationDeadLine = championship.EndDate,
            ChampDate = championship.StartDate
        };
    }

    private static PostChampionshipResponse MapToPostResponse(Championship championship)
    {
        return new PostChampionshipResponse
        {
            ChampId = championship.Id,
            ChampionshipName = championship.Name,
            ChampionshipDescription = championship.Description,
            RegistrationDeadLine = championship.EndDate,
            ChampDate = championship.StartDate
        };
    }

    private static PatchChampionshipResponse MapToPatchResponse(Championship championship)
    {
        return new PatchChampionshipResponse
        {
            ChampId = championship.Id,
            ChampionshipName = championship.Name,
            ChampionshipDescription = championship.Description,
            RegistrationDeadLine = championship.EndDate,
            ChampDate = championship.StartDate
        };
    }

    private static DeleteChampionshipResponse MapToDeleteResponse(Championship championship)
    {
        return new DeleteChampionshipResponse
        {
            ChampId = championship.Id,
            ChampionshipName = championship.Name,
            ChampionshipDescription = championship.Description,
            RegistrationDeadLine = championship.EndDate,
            ChampDate = championship.StartDate
        };
    }
}
