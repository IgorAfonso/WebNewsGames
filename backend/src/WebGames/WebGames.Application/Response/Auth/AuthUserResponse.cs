using WebGames.Application.Response;

namespace WebGames.Application.Response.Auth;

public class AuthUserResponse : ErrorResponse
{
    public string? UserId { get; set; }
    public string? UserName { get; set; }
    public string? Role { get; set; }
}
