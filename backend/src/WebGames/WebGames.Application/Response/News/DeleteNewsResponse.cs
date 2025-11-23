namespace WebGames.Application.Response.News;

public class DeleteNewsResponse
{
    public Guid Id { get; set; }
    public string? Title { get; set; }
    public string? Content { get; set; }
}
