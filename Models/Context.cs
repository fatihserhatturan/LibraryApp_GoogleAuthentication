using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Models
{
    public class Context : IdentityDbContext<AppUser, AppRole,int>
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-OFFTGKG;database=Library;Integrated Security=True;");
        }

        public DbSet<Book> Books { get; set; }
    }
}
