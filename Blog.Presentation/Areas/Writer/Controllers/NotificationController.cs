using Blog.Application.Contracts.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Presentation.Areas.Writer.Controllers;

[Area("Writer")]
[Authorize(Roles = "Writer")]
public class NotificationController : Controller
{
	private readonly INotificationService notificationService;

	public NotificationController(INotificationService notificationService)
		=> this.notificationService = notificationService;

    public async Task<IActionResult> All()
		=> View(await notificationService.GetAllAsync());
}
