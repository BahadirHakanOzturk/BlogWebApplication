using Blog.Application.Contracts.Services;
using Blog.Entities.Concrete;
using Blog.Entities.Concrete.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Presentation.Areas.Writer.Controllers;

[Area("Writer")]
[Authorize(Roles = "Writer")]
public class MessageController : Controller
{
	private readonly IMessageService messageService;
	private readonly UserManager<AppUser> userManager;

	public MessageController(IMessageService messageService, UserManager<AppUser> userManager)
	{
		this.messageService = messageService;
		this.userManager = userManager;
	}

	public async Task<IActionResult> Inbox()
	{
		var user = await userManager.FindByNameAsync(User.Identity.Name);
		return View(await messageService.GetInboxByWriterAsync(user.Id));
	}

	public async Task<IActionResult> SendBox()
	{
		var user = await userManager.FindByNameAsync(User.Identity.Name);
		return View(await messageService.GetOutboxByWriterAsync(user.Id));
	}

	public IActionResult SendMessage()
		=> View();

    [HttpPost]
	public async Task<IActionResult> SendMessage(Message message)
	{
		var sender = await userManager.FindByNameAsync(User.Identity.Name);
		message.SenderId = sender.Id;
		message.Status = true;
		message.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
		await messageService.AddAsync(message);
		return RedirectToAction("SendBox");
	}

	public async Task<IActionResult> Details(int id)
	{
		var values = await messageService.GetByIdAsync(id);
		return View(values.FirstOrDefault());
	}
}
