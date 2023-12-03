using Blog.Entities.Concrete.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Presentation.Areas.Writer.ViewComponents.Writer;

public class WriterDetails :ViewComponent
{
	private readonly UserManager<AppUser> userManager;

	public WriterDetails(UserManager<AppUser> userManager)
		=> this.userManager = userManager;

	public async Task<IViewComponentResult> InvokeAsync()
		=> View(await userManager.FindByNameAsync(User.Identity.Name));

}
