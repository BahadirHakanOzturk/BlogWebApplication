using Blog.Application.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Presentation.Areas.Writer.ViewComponents.Category;

public class CategoryListDashboard : ViewComponent
{
	private readonly ICategoryService categoryService;

	public CategoryListDashboard(ICategoryService categoryService)
		=> this.categoryService = categoryService;

	public async Task<IViewComponentResult> InvokeAsync()
		=> View(await categoryService.GetAllAsync());
}
