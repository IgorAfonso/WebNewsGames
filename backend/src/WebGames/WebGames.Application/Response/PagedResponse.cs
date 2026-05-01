using System.Text.Json.Serialization;

namespace WebGames.Application.Response;

public class PagedResponse<T> : ErrorResponse
{
    public IReadOnlyList<T> Items { get; set; } = [];
    public int Page { get; set; }
    public int PageSize { get; set; }
    public int TotalItems { get; set; }
    public int TotalPages { get; set; }
}
