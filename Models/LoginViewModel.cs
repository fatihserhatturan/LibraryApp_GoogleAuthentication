using System.ComponentModel.DataAnnotations;

namespace LibraryApp.Models
{
    public class LoginViewModel
    {
        [Display(Name = "Username")]
        [Required(ErrorMessage = "UserName Giriniz")]
        public string UserName { get; set; }

        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Şifre Giriniz")]
        public string Password { get; set; }
    }
}
