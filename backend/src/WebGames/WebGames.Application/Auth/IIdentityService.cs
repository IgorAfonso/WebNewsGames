using WebGames.Application.Response.Auth;

namespace WebGames.Application.Auth;

public interface IIdentityService
{
    Task<(bool Success, string ErrorMessage, AuthUserResponse User)> CreateUser(string userName, string password, string role);
    Task<(bool Success, string ErrorMessage, LoginResponse Login)> Login(string userName, string password);
}
