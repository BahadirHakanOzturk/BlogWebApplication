using Blog.Application.Contracts.Services;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using static System.Net.WebRequestMethods;

namespace Blog.Presentation.Areas.Admin.ViewComponents.Statistic;

public class BlogStatistic : ViewComponent
{
	private readonly IBlogService blogService;
	private readonly IContactService contactService;
	private readonly ICommentService commentService;
	public BlogStatistic(IBlogService blogService, IContactService contactService, ICommentService commentService)
	{
		this.blogService = blogService;
		this.contactService = contactService;
		this.commentService = commentService;
	}

	public async Task<IViewComponentResult> InvokeAsync()
	{
		var blogs = await blogService.GetAllAsync();
		var contacts = await contactService.GetAllAsync();
		var comments = await commentService.GetAllAsync();
		ViewBag.value = blogs.Count();
		ViewBag.value2 = contacts.Count();
		ViewBag.value3 = comments.Count();
		//string api = "5679b7c98124a44f5ae802b523d9b38a";
		//string connection = "https://api.openweathermap.org/data/2.5/forecast?q=istanbul,tr&mode=xml&lang=tr&units=metric&appid=" + api;
		//XDocument document = XDocument.Load(connection);
		ViewBag.value4 = 18; // document.Descendants("temperature").ElementAt(0).Attribute("value").Value.Split('.')[0];
		return View();
	}
}
