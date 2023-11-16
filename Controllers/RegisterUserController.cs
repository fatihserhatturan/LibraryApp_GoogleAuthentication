using LibraryApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LibraryApp.Controllers
{
    [AllowAnonymous]
    public class RegisterUserController : Controller
    {

        private readonly UserManager<AppUser> _userManager;


        public RegisterUserController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
           UserSignInViewModel model = new UserSignInViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserSignInViewModel p)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser
                {
                    Email = p.Email,
                    UserName = p.UserName,

                };
                var result = await _userManager.CreateAsync(user, p.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }

            return View(p);
        }
    }
}
