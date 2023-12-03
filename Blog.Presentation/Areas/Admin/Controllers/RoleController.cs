using AutoMapper;
using Blog.Application.ViewModels;
using Blog.Entities.Concrete.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.Presentation.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class RoleController : Controller
{
	private readonly RoleManager<AppRole> roleManager;
	private readonly UserManager<AppUser> userManager;
	private readonly IMapper mapper;

	public RoleController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager, IMapper mapper)
	{
		this.roleManager = roleManager;
		this.userManager = userManager;
		this.mapper = mapper;
	}

	public async Task<IActionResult> Index()
	{
		var roles = await roleManager.Roles.ToListAsync();
		return View(roles);
	}

	public IActionResult Add()
		=> View();

    [HttpPost]
	public async Task<IActionResult> Add(RoleVM model)
	{
		if (ModelState.IsValid)
		{
			var newRole = mapper.Map<AppRole>(model);
			var result = await roleManager.CreateAsync(newRole);
			if (result.Succeeded)
			{
				return RedirectToAction("Index");
			}
			foreach (var item in result.Errors)
			{
				ModelState.AddModelError("", item.Description);
			}
		}
		return View();
	}

	public async Task<ActionResult> Update(int id)
	{
		var role = await roleManager.Roles.FirstOrDefaultAsync(x => x.Id == id);
		var model = mapper.Map<RoleUpdateVM>(role);
		return View(model);
	}

	[HttpPost]
	public async Task<ActionResult> Update(RoleUpdateVM model)
	{
		var updatedRole = mapper.Map<AppRole>(model);
		var result = await roleManager.UpdateAsync(updatedRole);
		if (result.Succeeded)
		{
			return RedirectToAction("Index");
		}
		return View(model);
	}

	public async Task<IActionResult> Delete(int id)
	{
		var role = await roleManager.Roles.FirstOrDefaultAsync(x => x.Id == id);
		var result = await roleManager.DeleteAsync(role);
		if (result.Succeeded)
		{
			return RedirectToAction("Index");
		}
		return View();
	}

	public async Task<IActionResult> ListUserRole()
	{
		var users = await userManager.Users.ToListAsync();
		return View(users);
	}

	public async Task<IActionResult> Assign(int id)
	{
		var user = await userManager.FindByIdAsync(id.ToString());
		var roles = await roleManager.Roles.ToListAsync();

		TempData["UserId"] = user.Id;

		var userRoles = await userManager.GetRolesAsync(user);

		List<RoleAssignVM> model = new List<RoleAssignVM>();

		foreach (var role in roles)
		{
			RoleAssignVM assignVM = new RoleAssignVM();
			assignVM.RoleId = role.Id;
			assignVM.Name = role.Name;
			assignVM.Exists = userRoles.Contains(role.Name);
			model.Add(assignVM);
		}

		return View(model);
	}

	[HttpPost]
	public async Task<IActionResult> Assign(List<RoleAssignVM> model)
	{
		var userId = (int)TempData["UserId"];
		var user = await userManager.FindByIdAsync(userId.ToString());
		foreach (var item in model)
		{
			if (item.Exists)
			{
				await userManager.AddToRoleAsync(user, item.Name);
			}
			else
			{
				await userManager.RemoveFromRoleAsync(user, item.Name);
			}
		}
		return RedirectToAction("ListUserRole");
	}
}
