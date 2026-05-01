namespace WebGames.Domain.Entities;

public class Article : BaseEntity
{
    public string? Title { get; set; }
    public string? Content { get; set; }
    public string? ImageBase64 { get; set; }
    public string? ImageCaption { get; set; }
    public string? Content2 { get; set; }
    public string? Image2Base64 { get; set; }
    public string? Image2Caption { get; set; }
    public string? Content3 { get; set; }
    public string? Image3Base64 { get; set; }
    public string? Image3Caption { get; set; }
    public DateTime PublishedDate { get; set; }
    public Guid? AuthorId { get; set; }
    public string? AuthorUserId { get; set; }
    public string? AuthorName { get; set; }
}
