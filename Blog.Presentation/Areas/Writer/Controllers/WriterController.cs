using AutoMapper;
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
	private readonly IMapper mapper;

	public WriterController(UserManager<AppUser> userManager, IMapper mapper)
	{
		this.userManager = userManager;
		this.mapper = mapper;
	}	

	public async Task<IActionResult> EditProfile()
	{
		var user = await userManager.FindByNameAsync(User.Identity.Name);
		var model = mapper.Map<UserUpdateVM>(user);
		
		return View(model);
	}

	[HttpPost]
	public async Task<IActionResult> EditProfile(UserUpdateVM model)
	{
		var user = await userManager.FindByNameAsync(User.Identity.Name);

		user.NameSurname = model.NameSurname;
		user.UserName = model.UserName;
		user.Title = model.Title;
		user.Email = model.Email;

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

		await userManager.UpdateAsync(user);
		return RedirectToAction("Index", "Dashboard");
	}
}
