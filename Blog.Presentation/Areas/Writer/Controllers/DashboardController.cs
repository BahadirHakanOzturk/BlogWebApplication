using Blog.Application.Contracts.Services;
using Blog.Entities.Concrete.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Presentation.Areas.Writer.Controllers;

[Area("Writer")]
[Authorize(Roles = "Writer")]
public class DashboardController : Controller
{
	private readonly IBlogService blogService;
	private readonly ICategoryService categoryService;
	private readonly UserManager<AppUser> userManager;

	public DashboardController(IBlogService blogService, ICategoryService categoryService, UserManager<AppUser> userManager)
	{
		this.blogService = blogService;
		this.userManager = userManager;
		this.categoryService = categoryService;
	}

	public async Task<IActionResult> Index()
	{
		var user = await userManager.FindByNameAsync(User.Identity.Name);

		ViewBag.totalBlog = await blogService.GetTotalCountAsync();
		ViewBag.writerBlogCount = await blogService.GetTotalCountByWriterAsync(user.Id);
		ViewBag.totalCategory = await categoryService.GetTotalCountAsync();
		return View(user);
	}	
}
