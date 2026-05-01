using WebGames.Application.Response;

namespace WebGames.Application.Response.Auth;

public class LoginResponse : ErrorResponse
{
    public string? Token { get; set; }
    public string? TokenType { get; set; }
    public DateTime ExpiresAt { get; set; }
    public string? UserId { get; set; }
    public string? UserName { get; set; }
    public IReadOnlyList<string> Roles { get; set; } = [];
}
