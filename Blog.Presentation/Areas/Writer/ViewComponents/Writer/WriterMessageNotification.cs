using Blog.Application.Contracts.Services;
using Blog.Entities.Concrete.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Presentation.Areas.Writer.ViewComponents.Writer;

public class WriterMessageNotification : ViewComponent
{
    private readonly IMessageService messageService;
    private readonly UserManager<AppUser> userManager;

    public WriterMessageNotification(IMessageService messageService, UserManager<AppUser> userManager)
    {
        this.messageService = messageService;
        this.userManager = userManager;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var user = await userManager.FindByNameAsync(User.Identity.Name);
        return View(await messageService.GetInboxByWriterAsync(user.Id));
    }
}
