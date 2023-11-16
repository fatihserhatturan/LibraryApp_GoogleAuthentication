using LibraryApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace LibraryApp.Controllers
{
  
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;
        Context context = new Context();

        public AdminController(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
           
           // var values = _roleManager.Roles.ToList();
            var books = context.Books.ToList();
            return View(books);
        }

        public IActionResult BookStatusChange(int id)
        {
            Book bookToStatusFalse = context.Books.FirstOrDefault(x => x.Id == id);

            if (bookToStatusFalse.Status == true)
            {
                bookToStatusFalse.Status = false;
            }
            else
            {
                bookToStatusFalse.Status = true;
            }

            context.Books.Update(bookToStatusFalse);
            context.SaveChanges();

            return RedirectToAction("Index","Admin");
        }

        public IActionResult InsertBook(Book book)
        {
            Book insertedBook = new Book
            {
                Name = book.Name,
                Writer = book.Writer,
                Status = true,
            };

            context.Books.Add(insertedBook);
            context.SaveChanges();

            return  RedirectToAction("Index","Admin");
        }
    }
}
