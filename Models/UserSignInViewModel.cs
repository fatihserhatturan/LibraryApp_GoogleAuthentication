using System.ComponentModel.DataAnnotations;

namespace LibraryApp.Models
{
    public class UserSignInViewModel
    {

        [Display(Name ="Kullanıcı Adı")]
        [Required(ErrorMessage ="Kullanıcı Adı Giriniz")]
        public string UserName { get; set; }

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "E-mail Giriniz")]
        public string Email { get; set; }

        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Şifre Giriniz")]
        public string Password { get; set; }

        [Display(Name = "Şifreler Uyuşmuyor")]
        [Required(ErrorMessage = "Şifreler Uyuşmuyor")]
        [Compare("Password", ErrorMessage = "Şifreler uyuşmuyor")]
        public string ConfirmPassword { get; set; }
    }
}
