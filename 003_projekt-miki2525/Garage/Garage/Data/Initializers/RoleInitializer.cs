using Garage.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Garage.Data.Initializers
{
    public static class RoleInitializer
    {
        public static async Task InitiateRoles(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.User.ToString()));
        }
    }
}
