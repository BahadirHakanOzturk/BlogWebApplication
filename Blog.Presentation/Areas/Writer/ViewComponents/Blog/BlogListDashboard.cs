using Blog.Application.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Presentation.Areas.Writer.ViewComponents.Blog;

public class BlogListDashboard : ViewComponent
{
	private readonly IBlogService blogService;

	public BlogListDashboard(IBlogService blogService)
		=> this.blogService = blogService;

	public async Task<IViewComponentResult> InvokeAsync()
		=> View(await blogService.GetLast10BlogsWithCategoryAsync());
}
