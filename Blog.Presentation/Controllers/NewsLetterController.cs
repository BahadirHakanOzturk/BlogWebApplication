using Blog.Application.Contracts.Services;
using Blog.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Presentation.Controllers;

[AllowAnonymous]
public class NewsLetterController : Controller
{
	private readonly INewsLetterService newsLetterService;

	public NewsLetterController(INewsLetterService newsLetterService)
		=> this.newsLetterService = newsLetterService;

    [HttpPost]
	public async Task<IActionResult> SubscribeMail(NewsLetter newsLetter)
	{
		await newsLetterService.AddAsync(newsLetter);
		return Json(newsLetter);
	}
}
