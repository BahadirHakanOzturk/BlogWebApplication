using Blog.Application.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Presentation.ViewComponents.Blog;

public class BlogLast3Posts : ViewComponent
{
	private readonly IBlogService blogService;

	public BlogLast3Posts(IBlogService blogService)
		=> this.blogService = blogService;

	public async Task<IViewComponentResult> InvokeAsync()
		=> View(await blogService.GetLast3BlogsAsync());
}
