using WebGames.Application.AppService.Interface;
using WebGames.Application.Auth;
using WebGames.Application.Request.Auth;
using WebGames.Application.Response.Auth;

namespace WebGames.Application.AppService;

public class AuthAppService(IIdentityService identityService) : IAuthAppService
{
    public async Task<(bool, AuthUserResponse)> CreateAdmin(CreateUserRequest request)
    {
        var validation = ValidateCreateUserRequest(request);

        if (!validation.Success)
            return (false, new AuthUserResponse { ErrorMessage = validation.ErrorMessage });

        var result = await identityService.CreateUser(request.UserName!, request.Password!, AuthRoles.Administrator);
        return result.Success
            ? (true, result.User)
            : (false, new AuthUserResponse { ErrorMessage = result.ErrorMessage });
    }

    public async Task<(bool, AuthUserResponse)> CreateUser(CreateUserRequest request)
    {
        var validation = ValidateCreateUserRequest(request);

        if (!validation.Success)
            return (false, new AuthUserResponse { ErrorMessage = validation.ErrorMessage });

        var result = await identityService.CreateUser(request.UserName!, request.Password!, AuthRoles.User);
        return result.Success
            ? (true, result.User)
            : (false, new AuthUserResponse { ErrorMessage = result.ErrorMessage });
    }

    public async Task<(bool, LoginResponse)> Login(LoginRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.UserName))
            return (false, new LoginResponse { ErrorMessage = "User name is required." });

        if (string.IsNullOrWhiteSpace(request.Password))
            return (false, new LoginResponse { ErrorMessage = "Password is required." });

        var result = await identityService.Login(request.UserName, request.Password);
        return result.Success
            ? (true, result.Login)
            : (false, new LoginResponse { ErrorMessage = result.ErrorMessage });
    }

    private static (bool Success, string ErrorMessage) ValidateCreateUserRequest(CreateUserRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.UserName))
            return (false, "User name is required.");

        if (string.IsNullOrWhiteSpace(request.Password))
            return (false, "Password is required.");

        return (true, string.Empty);
    }
}
