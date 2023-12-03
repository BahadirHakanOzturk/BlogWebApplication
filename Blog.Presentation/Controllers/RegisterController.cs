using AutoMapper;
using Blog.Application.ViewModels;
using Blog.Entities.Concrete.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Presentation.Controllers;

[AllowAnonymous]
public class RegisterController : Controller
{
    private readonly UserManager<AppUser> userManager;
    private readonly IMapper mapper;

    public RegisterController(UserManager<AppUser> userManager, IMapper mapper)
    {
        this.userManager = userManager;
        this.mapper = mapper;
    }

    public IActionResult Index()
        => View();

    [HttpPost]
    public async Task<IActionResult> Index(UserSignUpVM model)
    {
        if (ModelState.IsValid)
        {
            var hasher = new PasswordHasher<AppUser>();

            var newEntity = mapper.Map<AppUser>(model);
            newEntity.PasswordHash = hasher.HashPassword(newEntity, model.Password);
            await userManager.CreateAsync(newEntity);
            await userManager.AddToRoleAsync(newEntity, "Member");
            return RedirectToAction("Index", "Blog");
        }
        else
        {
            return View(model);
        }
    }
}