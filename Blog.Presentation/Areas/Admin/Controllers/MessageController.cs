using Blog.Application.Contracts.Services;
using Blog.Entities.Concrete;
using Blog.Entities.Concrete.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Blog.Presentation.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
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

	public IActionResult ComposeMessage()
		=> View();

    [HttpPost]
	public async Task<IActionResult> ComposeMessage(Message message)
	{
		int id = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
		message.SenderId = id;
		message.ReceiverId = 2;
		message.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
		message.Status = true;
		await messageService.AddAsync(message);
		return RedirectToAction("SendBox");
	}
}
