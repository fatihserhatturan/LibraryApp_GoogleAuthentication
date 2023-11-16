using Microsoft.AspNetCore.Identity;

namespace LibraryApp.Models
{
    public class AppUser :IdentityUser<int>
    {
        public string Surname { get; set; }
    }
}
