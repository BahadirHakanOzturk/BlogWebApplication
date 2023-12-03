using Blog.Application.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Presentation.Areas.Admin.ViewComponents.Statistic;

public class LastBlogStatistic : ViewComponent
{
	private readonly IBlogService blogService;
	public LastBlogStatistic(IBlogService blogService)
	{
		this.blogService = blogService;
	}

	public async Task<IViewComponentResult> InvokeAsync()
	{
		var last3Blogs = await blogService.GetLast3BlogsAsync();
		ViewBag.value = last3Blogs.FirstOrDefault().Title;
		return View();
	}
}
