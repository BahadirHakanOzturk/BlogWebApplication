using Blog.Application.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Presentation.ViewComponents.Blog;

public class WriterLastBlogsList : ViewComponent
{
	private readonly IBlogService blogService;

	public WriterLastBlogsList(IBlogService blogService)
		=> this.blogService = blogService;

	public async Task<IViewComponentResult> InvokeAsync(int id)
		=> View(await blogService.GetListByWriterAsync(id));
}
