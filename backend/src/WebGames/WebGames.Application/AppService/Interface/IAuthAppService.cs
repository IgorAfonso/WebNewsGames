using WebGames.Application.Request.Auth;
using WebGames.Application.Response.Auth;

namespace WebGames.Application.AppService.Interface;

public interface IAuthAppService
{
    Task<(bool, AuthUserResponse)> CreateAdmin(CreateUserRequest request);
    Task<(bool, AuthUserResponse)> CreateUser(CreateUserRequest request);
    Task<(bool, LoginResponse)> Login(LoginRequest request);
}
