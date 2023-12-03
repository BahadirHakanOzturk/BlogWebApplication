using Blog.Application.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Presentation.Areas.Writer.ViewComponents.Writer;

public class WriterNotification : ViewComponent
{
    private readonly INotificationService notificationService;

    public WriterNotification(INotificationService notificationService)
        => this.notificationService = notificationService;

	public async Task<IViewComponentResult> InvokeAsync()
		=> View(await notificationService.GetAllAsync());
}
