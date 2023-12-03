using Blog.Application.ViewModels;
using Blog.Entities.Concrete.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Blog.Presentation.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class WriterController : Controller
{
	private readonly UserManager<AppUser> userManager;
	public WriterController(UserManager<AppUser> userManager)
		=> this.userManager = userManager;

    public IActionResult Index()
		=> View();

    public async Task<IActionResult> List()
	{
		var data = await userManager.GetUsersInRoleAsync("Writer");
		var jsonWriters = JsonConvert.SerializeObject(data);
		return Json(jsonWriters);
	}

	public async Task<IActionResult> GetById(int writerId)
	{
		var writer = await userManager.FindByIdAsync(writerId.ToString());
		var jsonWriter = JsonConvert.SerializeObject(writer);
		return Json(jsonWriter);
	}

	[HttpPost]
	public async Task<IActionResult> Delete(int writerId)
	{
		var writer = await userManager.FindByIdAsync(writerId.ToString());
		await userManager.DeleteAsync(writer);
		return Json(writer);
	}

	[HttpPost]
	public async Task<IActionResult> Update(WriterUpdateVM model)
	{
		var writer = await userManager.FindByIdAsync(model.Id.ToString());
		writer.NameSurname = model.NameSurname;
		await userManager.UpdateAsync(writer);
		var jsonWriter = JsonConvert.SerializeObject(writer);
		return Json(jsonWriter);
	}
}
