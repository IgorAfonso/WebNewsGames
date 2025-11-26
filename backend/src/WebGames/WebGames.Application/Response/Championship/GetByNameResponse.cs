namespace WebGames.Application.Response.Championship;

public class GetByNameResponse
{
    public Guid ChampId { get; set; }
    public string? ChampionshipName { get; set; }
    public string? ChampionshipDescription { get; set; }
    public DateTime? RegistrationDeadLine { get; set; }
    public DateTime? ChampDate { get; set; }
}
