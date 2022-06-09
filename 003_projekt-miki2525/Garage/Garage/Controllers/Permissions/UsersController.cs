using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Garage.Controllers.Permissions
{
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        public UsersController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        [Route("users")]
        public async Task<IActionResult> Index()
        {
            var loggedUser = await _userManager.GetUserAsync(HttpContext.User);
            var listOfUsers = await _userManager.Users.Where(a => a.Id != loggedUser.Id).ToListAsync();
            return View(listOfUsers);
        }
    }
}
