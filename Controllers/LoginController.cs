using LibraryApp.Models;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace LibraryApp.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        
        private readonly UserManager<AppUser> _userManager;

        public LoginController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public async Task GoogleLogin()
        {
            await HttpContext.ChallengeAsync(GoogleDefaults.AuthenticationScheme, new AuthenticationProperties()
            {
                RedirectUri = Url.Action("GoogleResponse")
            });

        }
        public async Task<IActionResult> GoogleResponse()
        {
            var result = await HttpContext.AuthenticateAsync("Google");

            var claims = result.Principal.Identities
                .FirstOrDefault().Claims.Select(claim => new
                {
                    claim.Issuer,
                    claim.OriginalIssuer,
                    claim.Type,
                    claim.Value,

                });

            if (!result.Succeeded)
            {
                return RedirectToAction("Index", "Login");
            }
   
            var userEmailClaim = result.Principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email);

            if (userEmailClaim != null)
            {
                var normalizedEmail = _userManager.NormalizeEmail(userEmailClaim.Value);
               
                var existingUser = await _userManager.FindByEmailAsync(normalizedEmail);
                
                await _signInManager.SignInAsync(existingUser, isPersistent: false);

                return RedirectToAction("Index", "Library");
            }
            return RedirectToAction("Index", "Login");
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index","Home");
        }

        [HttpGet]
        public IActionResult Index()
        {
            LoginViewModel loginViewModel = new LoginViewModel();
            return View(loginViewModel);
        }


        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel p)
        {
            var result = await _signInManager.PasswordSignInAsync(p.UserName, p.Password, false, true);
            if(result.Succeeded)
            {
                return RedirectToAction("Index","Library");
            }
            else
            {
                return View();
            }

        }

    }
}
