using Blog.Application.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Presentation.ViewComponents.Category;

public class CategoryList : ViewComponent
{
	private readonly ICategoryService categoryService;

	public CategoryList(ICategoryService categoryService)
		=> this.categoryService = categoryService;

	public async Task<IViewComponentResult> InvokeAsync()
		=> View(await categoryService.GetCategoryListWithBlogAsync());
}
