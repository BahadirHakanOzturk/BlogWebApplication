using Blog.Application.ViewModels;
using Blog.Entities.Concrete.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Presentation.Areas.Writer.Controllers;

[Area("Writer")]
[Authorize(Roles = "Writer")]
public class WriterController : Controller
{
	private readonly UserManager<AppUser> userManager;

	public WriterController(UserManager<AppUser> userManager)
		=> this.userManager = userManager;

	public async Task<IActionResult> EditProfile()
	{
		var user = await userManager.FindByNameAsync(User.Identity.Name);
		UserUpdateVM model = new UserUpdateVM();
		model.Mail = user.Email;
		model.NameSurname = user.NameSurname;
		model.Title = user.Title;
		model.ImageUrl = user.ImageUrl;
		model.UserName = user.UserName;
		model.About = user.About;
		return View(model);
	}

	[HttpPost]
	public async Task<IActionResult> EditProfile(UserUpdateVM model)
	{
		var user = await userManager.FindByNameAsync(User.Identity.Name);
		user.NameSurname = model.NameSurname;
		user.Title = model.Title;
		user.Email = model.Mail;
		if (model.Password != null)
		{
			user.PasswordHash = userManager.PasswordHasher.HashPassword(user, model.Password);
		}
		if (model.Image != null)
		{
			var extension = Path.GetExtension(model.Image.FileName);
			var newImageName = Guid.NewGuid() + extension;
			var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", newImageName);
			var stream = new FileStream(location, FileMode.Create);
			model.Image.CopyTo(stream);
			user.ImageUrl = Path.Combine("/WriterImageFiles/", newImageName);
		}
		user.About = model.About;
		var result = await userManager.UpdateAsync(user);
		return RedirectToAction("Index", "Dashboard");
	}
}
