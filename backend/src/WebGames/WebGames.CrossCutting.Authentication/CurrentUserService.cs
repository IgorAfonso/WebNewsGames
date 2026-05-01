using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using WebGames.Application.Auth;

namespace WebGames.CrossCutting.Authentication;

public class CurrentUserService(IHttpContextAccessor httpContextAccessor) : ICurrentUserService
{
    private ClaimsPrincipal? User => httpContextAccessor.HttpContext?.User;

    public bool IsAuthenticated => User?.Identity?.IsAuthenticated == true;

    public string? UserId => User?.FindFirstValue(ClaimTypes.NameIdentifier);

    public string? UserName => User?.FindFirstValue(ClaimTypes.Name);

    public bool IsInRole(string role)
    {
        return User?.IsInRole(role) == true;
    }
}
