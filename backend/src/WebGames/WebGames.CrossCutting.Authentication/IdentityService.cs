using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using WebGames.Application.Auth;
using WebGames.Application.Response.Auth;

namespace WebGames.CrossCutting.Authentication;

public class IdentityService(
    UserManager<IdentityUser> userManager,
    SignInManager<IdentityUser> signInManager,
    IConfiguration configuration) : IIdentityService
{
    public async Task<(bool Success, string ErrorMessage, AuthUserResponse User)> CreateUser(
        string userName,
        string password,
        string role)
    {
        var existingUser = await userManager.FindByNameAsync(userName);

        if (existingUser is not null)
            return (false, "Não é possível criar com este usuário.", new AuthUserResponse());

        var user = new IdentityUser
        {
            UserName = userName,
            Email = $"{userName}@webnewsgames.local",
            EmailConfirmed = true
        };

        var createResult = await userManager.CreateAsync(user, password);

        if (!createResult.Succeeded)
            return (false, string.Join(" ", createResult.Errors.Select(error => error.Description)), new AuthUserResponse());

        var roleResult = await userManager.AddToRoleAsync(user, role);

        if (!roleResult.Succeeded)
            return (false, string.Join(" ", roleResult.Errors.Select(error => error.Description)), new AuthUserResponse());

        return (true, string.Empty, new AuthUserResponse
        {
            UserId = user.Id,
            UserName = user.UserName,
            Role = role
        });
    }

    public async Task<(bool Success, string ErrorMessage, LoginResponse Login)> Login(string userName, string password)
    {
        var user = await userManager.FindByNameAsync(userName);

        if (user is null)
            return (false, "Usuário ou senha inválidos.", new LoginResponse());

        var signInResult = await signInManager.CheckPasswordSignInAsync(user, password, false);

        if (!signInResult.Succeeded)
            return (false, "Usuário ou senha inválidos.", new LoginResponse());

        var roles = await userManager.GetRolesAsync(user);
        var expiresAt = DateTime.UtcNow.AddHours(8);
        var token = GenerateToken(user, roles, expiresAt);

        return (true, string.Empty, new LoginResponse
        {
            Token = token,
            TokenType = "Bearer",
            ExpiresAt = expiresAt,
            UserId = user.Id,
            UserName = user.UserName,
            Roles = roles.ToList()
        });
    }

    private string GenerateToken(IdentityUser user, IEnumerable<string> roles, DateTime expiresAt)
    {
        var jwtKey = configuration["Jwt:Key"];

        if (string.IsNullOrWhiteSpace(jwtKey))
            throw new InvalidOperationException("Jwt:Key was not configured.");

        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.Id),
            new(ClaimTypes.Name, user.UserName ?? string.Empty),
            new(JwtRegisteredClaimNames.Sub, user.Id),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            issuer: configuration["Jwt:Issuer"],
            audience: configuration["Jwt:Audience"],
            claims: claims,
            expires: expiresAt,
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
