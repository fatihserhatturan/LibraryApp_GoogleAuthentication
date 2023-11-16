using LibraryApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace LibraryApp.Controllers
{
    public class BookmarkController : Controller
    {
        Singleton singleton = Singleton.GetInstance();
        Context context = new Context();
        public IActionResult Index()
        {
            return View(singleton.books);
        }

        public IActionResult AddBookmark(int id)
        {
           
            Book book = context.Books.SingleOrDefault(x => x.Id == id);
            singleton.books.Add(book);

            return RedirectToAction("Index","Home");
        }
        public IActionResult RemoveBookmark(int id)
        {
            Book bookToRemove = singleton.books.Find(x => x.Id == id);
            singleton.books.Remove(bookToRemove);
            return RedirectToAction("Index","Bookmark");
        }

        [Authorize(Roles ="User")]
        public IActionResult ConfirmBookmark()
        {
            List<Book> books = singleton.books.ToList();

            foreach(Book book in books)
            {
              Book updatedBook =  context.Books.SingleOrDefault(x => x.Id == book.Id);
              updatedBook.Status = false;
              context.Books.Update(updatedBook);
              context.SaveChanges();
            }

            singleton.books.Clear();
            return  RedirectToAction("Index","Bookmark");
        }
    }
}
