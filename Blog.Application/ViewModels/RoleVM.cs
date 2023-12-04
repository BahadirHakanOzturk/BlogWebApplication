using System.ComponentModel.DataAnnotations;

namespace Blog.Application.ViewModels;

public class RoleVM
{
	[Required(ErrorMessage = "Lütfen rol adı giriniz")]
	public string Name { get; set; }
}
