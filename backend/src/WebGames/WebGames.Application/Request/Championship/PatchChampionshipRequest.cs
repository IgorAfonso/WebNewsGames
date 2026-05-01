namespace WebGames.Application.Request.Championship;

public class PatchChampionshipRequest
{
    public Guid ChampId { get; set; }
    public string? ChampionshipName { get; set; }
    public string? ChampionshipDescription { get; set; }
    public DateTime? RegistrationDeadLine { get; set; }
    public DateTime? ChampDate { get; set; }
}
