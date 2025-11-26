namespace WebGames.Application.Request.Championship;

public class PostChampionshipRequest
{
    public string? ChampionshipName { get; set; }
    public string? ChampionshipDescription { get; set; }
    public DateTime? RegistrationDeadLine { get; set; }
    public DateTime? ChampDate { get; set; }
}
