using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using WebGames.Application.Auth;

namespace WebGames.CrossCutting.Authentication;

public static class IdentitySeeder
{
    public static async Task SeedAsync(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

        await EnsureRole(roleManager, AuthRoles.Administrator);
        await EnsureRole(roleManager, AuthRoles.User);
        await EnsureManager(userManager);
    }

    private static async Task EnsureRole(RoleManager<IdentityRole> roleManager, string role)
    {
        if (!await roleManager.RoleExistsAsync(role))
            await roleManager.CreateAsync(new IdentityRole(role));
    }

    private static async Task EnsureManager(UserManager<IdentityUser> userManager)
    {
        const string managerUserName = "manager";
        const string managerPassword = "webnews123";

        var manager = await userManager.FindByNameAsync(managerUserName);

        if (manager is null)
        {
            manager = new IdentityUser
            {
                UserName = managerUserName,
                Email = "manager@webnewsgames.local",
                EmailConfirmed = true
            };

            var createResult = await userManager.CreateAsync(manager, managerPassword);

            if (!createResult.Succeeded)
                throw new InvalidOperationException(string.Join(" ", createResult.Errors.Select(error => error.Description)));
        }

        if (!await userManager.IsInRoleAsync(manager, AuthRoles.Administrator))
            await userManager.AddToRoleAsync(manager, AuthRoles.Administrator);
    }
}
