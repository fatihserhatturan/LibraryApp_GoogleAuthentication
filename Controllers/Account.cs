using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.Controllers
{
    public class Account : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
