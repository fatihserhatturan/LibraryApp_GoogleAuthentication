using LibraryApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LibraryApp.Controllers
{
    [Authorize(Roles ="User,Admin,Super")]
    public class LibraryController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public LibraryController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task <IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.v = user;

            return View();
        }
    }
}
