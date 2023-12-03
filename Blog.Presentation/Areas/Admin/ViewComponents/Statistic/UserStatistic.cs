using Blog.Application.Contracts.Services;
using Blog.Entities.Concrete.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Presentation.Areas.Admin.ViewComponents.Statistic;

public class UserStatistic : ViewComponent
{
    private readonly UserManager<AppUser> userManager;

    public UserStatistic(UserManager<AppUser> userManager)
    {
        this.userManager = userManager;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var user = await userManager.FindByNameAsync(User.Identity.Name);
        ViewBag.NameSurname = user.NameSurname;
        ViewBag.Image = user.ImageUrl;
        ViewBag.About = user.About;
        return View();
    }
}
