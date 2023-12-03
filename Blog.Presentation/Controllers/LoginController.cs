using Blog.Application.ViewModels;
using Blog.Entities.Concrete.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Presentation.Controllers;

[AllowAnonymous]
public class LoginController : Controller
{
	private readonly SignInManager<AppUser> signInManager;
	private readonly UserManager<AppUser> userManager;

	public LoginController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
	{
		this.signInManager = signInManager;
		this.userManager = userManager;
	}

	public IActionResult Index()
		=> View();

	[HttpPost]
	public async Task<IActionResult> Index(UserSignInVM model)
	{
		if (ModelState.IsValid)
		{
			var user = await userManager.FindByEmailAsync(model.Email);
			var result = await signInManager.PasswordSignInAsync(user.UserName, model.Password, false, true);
			if (result.Succeeded)
			{
				if(await userManager.IsInRoleAsync(user, "Admin"))
				{
					return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
				}
				else if (await userManager.IsInRoleAsync(user, "Writer"))
				{
					return RedirectToAction("Index", "Dashboard", new { area = "Writer" });
				}
				else
				{
					return RedirectToAction("Index", "Blog");
				}
				
			}
			else
			{
				return RedirectToAction("Index", "Login");
			}
		}
		return View();
	}

	public async Task<IActionResult> Logout()
	{
		await signInManager.SignOutAsync();
		return RedirectToAction("Index", "Login");
	}
}