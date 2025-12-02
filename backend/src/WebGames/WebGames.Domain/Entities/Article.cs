namespace WebGames.Domain.Entities;

public class Article : BaseEntity
{
    public string? Title { get; set; }
    public string? Content { get; set; }
    public DateTime PublishedDate { get; set; }
    public Guid? AuthorId { get; set; }
    public string? SecondContent { get; set; }
}
