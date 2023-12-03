using Blog.Application.Contracts.Services;
using Blog.Presentation.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Presentation.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class ChartController : Controller
{
	private readonly ICategoryService categoryService;
	private readonly IBlogService blogService;

	public ChartController(ICategoryService categoryService, IBlogService blogService)
	{
		this.categoryService = categoryService;
		this.blogService = blogService;
	}

	public IActionResult Index()
		=> View();

	public async Task<IActionResult> CategoryChart()
	{
		var categories = await categoryService.GetAllAsync();
		var blogs = await blogService.GetBlogListWithCategoryAsync();

		List<CategoryChartModel> list = new List<CategoryChartModel>();

		foreach (var category in categories)
		{
			list.Add(new CategoryChartModel { CategoryName = category.Name, CategoryCount = blogs.Where(b => b.Category.Name == category.Name).Count() });
		}

		return Json(new { jsonlist = list });
	}
}
