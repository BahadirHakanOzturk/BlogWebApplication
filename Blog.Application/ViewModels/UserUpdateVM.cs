using Microsoft.AspNetCore.Http;

namespace Blog.Application.ViewModels;

public class UserUpdateVM
{
    public string NameSurname { get; set; }
    public string UserName { get; set; }
    public string Title {  get; set; }
    public string Email { get; set; }
    public string ImageUrl { get; set; }
    public string Password { get; set; }
    public string About { get; set; }
	public IFormFile Image { get; set; }
}
