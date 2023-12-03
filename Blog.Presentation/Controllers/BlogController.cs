using Blog.Application.Contracts.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Presentation.Controllers;

[AllowAnonymous]
public class BlogController : Controller
{
	private readonly IBlogService blogService;

	public BlogController(IBlogService blogService)
		=> this.blogService = blogService;

	public async Task<IActionResult> Index()
		=> View(await blogService.GetBlogListWithCategoryAsync());

	public async Task<IActionResult> ReadAll(int id)
	{
		TempData["Id"] = id;
		return View(await blogService.GetByIdAsync(id));
	}

    public IActionResult About()
		=> View();
}
