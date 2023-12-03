using Blog.Application.Contracts.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Presentation.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class BlogController : Controller
{
	private readonly IBlogService blogService;

	public BlogController(IBlogService blogService)
		=> this.blogService = blogService;

	public async Task<IActionResult> Index()
		=> View(await blogService.GetBlogListWithCategoryAsync());
}
