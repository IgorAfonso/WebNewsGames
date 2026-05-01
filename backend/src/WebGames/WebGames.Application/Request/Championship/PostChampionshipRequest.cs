namespace WebGames.Application.Request.Championship;

public class PostChampionshipRequest
{
    public string? ChampionshipName { get; set; }
    public string? ChampionshipDescription { get; set; }
    public string? ChampionshipSystem { get; set; }
    public string? Place { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}
