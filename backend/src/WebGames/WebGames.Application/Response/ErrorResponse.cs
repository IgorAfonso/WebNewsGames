using System.Text.Json.Serialization;

namespace WebGames.Application.Response;

public abstract class ErrorResponse
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ErrorMessage { get; set; }
}
