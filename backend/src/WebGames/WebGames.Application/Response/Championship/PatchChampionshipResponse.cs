namespace WebGames.Application.Response.Championship;

public class PatchChampionshipResponse
{
    public Guid ChampId { get; set; }
    public string? ChampionshipName { get; set; }
    public string? ChampionshipDescription { get; set; }
    public DateTime? RegistrationDeadLine { get; set; }
    public DateTime? ChampDate { get; set; }
}
