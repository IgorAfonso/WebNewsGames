using WebGames.Application.Response;

namespace WebGames.Application.Response.Championship;

public class GetByIdResponse : ErrorResponse
{
    public Guid ChampId { get; set; }
    public string? ChampionshipName { get; set; }
    public string? ChampionshipDescription { get; set; }
    public string? ChampionshipSystem { get; set; }
    public string? Place { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public bool IsExhibitionOnly { get; set; }
}
