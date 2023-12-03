using Blog.Entities.Concrete.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Presentation.Areas.Admin.ViewComponents.User;

public class UserDetails : ViewComponent
{
	private readonly UserManager<AppUser> userManager;

	public UserDetails(UserManager<AppUser> userManager)
		=> this.userManager = userManager;

	public async Task<IViewComponentResult> InvokeAsync()
		=> View(await userManager.FindByNameAsync(User.Identity.Name));
}
