using WebGames.Application.Response.Championship;
using WebGames.Domain.Entities;

namespace WebGames.Application.Mappers;

public static class ChampionshipMapper
{
    public static GetByIdResponse ToGetByIdResponse(Championship championship)
    {
        return new GetByIdResponse
        {
            ChampId = championship.Id,
            ChampionshipName = championship.Name,
            ChampionshipDescription = championship.Description,
            ChampionshipSystem = championship.System,
            Place = championship.Place,
            StartDate = championship.StartDate,
            EndDate = championship.EndDate,
            IsExhibitionOnly = championship.IsExhibitionOnly
        };
    }

    public static PostChampionshipResponse ToPostResponse(Championship championship)
    {
        return new PostChampionshipResponse
        {
            ChampId = championship.Id,
            ChampionshipName = championship.Name,
            ChampionshipDescription = championship.Description,
            ChampionshipSystem = championship.System,
            Place = championship.Place,
            StartDate = championship.StartDate,
            EndDate = championship.EndDate,
            IsExhibitionOnly = championship.IsExhibitionOnly
        };
    }

    public static PatchChampionshipResponse ToPatchResponse(Championship championship)
    {
        return new PatchChampionshipResponse
        {
            ChampId = championship.Id,
            ChampionshipName = championship.Name,
            ChampionshipDescription = championship.Description,
            ChampionshipSystem = championship.System,
            Place = championship.Place,
            StartDate = championship.StartDate,
            EndDate = championship.EndDate,
            IsExhibitionOnly = championship.IsExhibitionOnly
        };
    }

    public static DeleteChampionshipResponse ToDeleteResponse(Championship championship)
    {
        return new DeleteChampionshipResponse
        {
            ChampId = championship.Id,
            ChampionshipName = championship.Name,
            ChampionshipDescription = championship.Description,
            ChampionshipSystem = championship.System,
            Place = championship.Place,
            StartDate = championship.StartDate,
            EndDate = championship.EndDate,
            IsExhibitionOnly = championship.IsExhibitionOnly
        };
    }
}
