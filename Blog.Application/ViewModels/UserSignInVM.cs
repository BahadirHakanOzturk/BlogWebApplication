using System.ComponentModel.DataAnnotations;

namespace Blog.Application.ViewModels;

public class UserSignInVM
{
    [Required(ErrorMessage ="Lütfen mail adresinizi girin")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Lütfen şifrenizi girin")]
    public string Password { get; set; }
}
