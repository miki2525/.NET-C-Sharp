using Garage.Models;
using Garage.Models.Authentication;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Garage.Data.Initializers
{
    public static class UserInitializer
    {
        public static async Task InitializeUser(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var defaultUser = new IdentityUser
            {
                UserName = "user@test.com",
                Email = "user@test.com",
                EmailConfirmed = true
            };
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "userUSER123!");
                    await userManager.AddToRoleAsync(defaultUser, Roles.User.ToString());
                }
            }
            var defaultUser2 = new IdentityUser
            {
                UserName = "user2@test.com",
                Email = "user2@test.com",
                EmailConfirmed = true
            };
            if (userManager.Users.All(u => u.Id != defaultUser2.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser2.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser2, "userUSER123!");
                    await userManager.AddToRoleAsync(defaultUser2, Roles.User.ToString());
                }
            }
             var userRole = await roleManager.FindByNameAsync(Roles.User.ToString());
            await roleManager.AddClaimAsync(userRole, new Claim("Permission", "Permissions.Garage.View"));
        }
        public static async Task InitializeAdmin(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var defaultUser = new IdentityUser
            {
                UserName = "admin@test.com",
                Email = "admin@test.com",
                EmailConfirmed = true
            };
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "adminADMIN123!");
                    await userManager.AddToRoleAsync(defaultUser, Roles.User.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Roles.Admin.ToString());
                }
                
            }
            await roleManager.LoadPermissionsForAdmin();
        }
        private async static Task LoadPermissionsForAdmin(this RoleManager<IdentityRole> roleManager)
        {
            var adminRole = await roleManager.FindByNameAsync(Roles.Admin.ToString());
            await roleManager.AddPermissionToRole(adminRole, "Garage");
        }
        public static async Task AddPermissionToRole(this RoleManager<IdentityRole> roleManager, IdentityRole role, string module)
        {
            var allClaimedPermissions = await roleManager.GetClaimsAsync(role);
            var allPermissions = Permissions.GeneratePermissionsForModule(module);
            foreach (var permission in allPermissions)
            {
                if (!allClaimedPermissions.Any(a => a.Type == "Permission" && a.Value == permission))
                {
                    await roleManager.AddClaimAsync(role, new Claim("Permission", permission));
                }
            }
        }
    }
}
