using Blog.Application.Contracts.Services;
using Blog.Application.ValidationRules;
using Blog.Application.ViewModels;
using Blog.Entities.Concrete;
using Blog.Entities.Concrete.User;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Blog.Presentation.Areas.Writer.Controllers;

[Area("Writer")]
[Authorize(Roles = "Writer")]
public class BlogController : Controller
{
	private readonly ICategoryService categoryService;
	private readonly IBlogService blogService;
	private readonly UserManager<AppUser> userManager;

	public BlogController(IBlogService blogService, ICategoryService categoryService, UserManager<AppUser> userManager)
	{
		this.blogService = blogService;
		this.categoryService = categoryService;
		this.userManager = userManager;
	}

	public async Task<IActionResult> Add()
	{
		List<Category> categories = (List<Category>)await categoryService.GetAllAsync();
		//List<SelectListItem> categoryValues = (from x in await categoryService.GetAllAsync()
		//									   select new SelectListItem
		//									   {
		//										   Text = x.Name,
		//										   Value = x.Id.ToString()
		//									   }).ToList();
		BlogAddVM model = new BlogAddVM();		
		model.CategoryList = categories;
		return View(model);
	}

	[HttpPost]
	public async Task<IActionResult> Add(Entities.Concrete.Blog blog)
	{
		var user = await userManager.FindByNameAsync(User.Identity.Name);

		BlogValidator bv = new BlogValidator();
		ValidationResult results = bv.Validate(blog);
		if (results.IsValid)
		{
			blog.Status = true;
			blog.CreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
			blog.UserId = user.Id;
			blog.CategoryId = 2;
			await blogService.AddAsync(blog);
			return RedirectToAction("ListByWriter", "Blog");
		}
		else
		{
			foreach (var item in results.Errors)
			{
				ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
			}
		}
		return View();
	}

	public async Task<IActionResult> Edit(int id)
	{
		var blogvalue = await blogService.GetByIdAsync(id);
		List<SelectListItem> categoryValues = (from x in await categoryService.GetAllAsync()
											   select new SelectListItem
											   {
												   Text = x.Name,
												   Value = x.Id.ToString()
											   }).ToList();
		ViewBag.cv = categoryValues;
		return View(blogvalue);
	}

	[HttpPost]
	public async Task<IActionResult> Edit(Entities.Concrete.Blog blog)
	{

		var user = await userManager.FindByNameAsync(User.Identity.Name);

		blog.CreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
		blog.UserId = user.Id;
		blog.Status = true;
		await blogService.UpdateAsync(blog);
		return RedirectToAction("ListByWriter");
	}

	public async Task<IActionResult> Delete(int id)
	{
		var blogvalue = await blogService.GetByIdAsync(id);
		await blogService.DeleteAsync(blogvalue);
		return RedirectToAction("ListByWriter");
	}

	public async Task<IActionResult> ListByWriter()
    {
        var user = await userManager.FindByNameAsync(User.Identity.Name);
        return View(await blogService.GetListWithCategoryByWriterAsync(user.Id));
    }
}
