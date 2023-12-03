using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.ViewModels;

public class UserSignInVM
{
    [Required(ErrorMessage ="Lütfen mail adresinizi girin")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Lütfen şifrenizi girin")]
    public string Password { get; set; }
}
