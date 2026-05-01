namespace WebGames.Domain.Entities;

public class Championship : BaseEntity
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? System { get; set; }
    public string? Place { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsExhibitionOnly { get; set; } = true;
}
