using AutoMapper;
using Blog.Application.Contracts.Services;
using Blog.Application.ViewModels;
using Blog.Entities.Concrete;
using Blog.Entities.Concrete.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Presentation.Areas.Writer.Controllers;

[Area("Writer")]
[Authorize(Roles = "Writer")]
public class BlogController : Controller
{
	private readonly ICategoryService categoryService;
	private readonly IBlogService blogService;
	private readonly UserManager<AppUser> userManager;
	private readonly IMapper mapper;

	public BlogController(IBlogService blogService, ICategoryService categoryService, UserManager<AppUser> userManager, IMapper mapper)
	{
		this.blogService = blogService;
		this.categoryService = categoryService;
		this.userManager = userManager;
		this.mapper = mapper;
	}

	public async Task<IActionResult> Add()
	{
		List<Category> categories = (List<Category>)await categoryService.GetAllAsync();
		ViewBag.CategoryList = categories;
		return View();
	}

	[HttpPost]
	public async Task<IActionResult> Add(BlogAddVM model)
	{
		var user = await userManager.FindByNameAsync(User.Identity.Name);

		if (ModelState.IsValid)
		{
			var newBlog = mapper.Map<Entities.Concrete.Blog>(model);
			newBlog.UserId = user.Id;
			if (model.Image != null)
			{
				var extension = Path.GetExtension(model.Image.FileName);
				var newImageName = Guid.NewGuid() + extension;
				var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/BlogImageFiles/", newImageName);
				var stream = new FileStream(location, FileMode.Create);
				model.Image.CopyTo(stream);
				newBlog.ImageUrl = Path.Combine("/BlogImageFiles/", newImageName);
			}
			await blogService.AddAsync(newBlog);
			return RedirectToAction("ListByWriter", "Blog");
		}

		else
		{
			List<Category> categories = (List<Category>)await categoryService.GetAllAsync();
			ViewBag.CategoryList = categories;
			return View(model);
		}
	}

	public async Task<IActionResult> Edit(int id)
	{
		var blog = await blogService.GetByIdAsync(id);
		
		var model = mapper.Map<BlogUpdateVM>(blog);

		List<Category> categories = (List<Category>)await categoryService.GetAllAsync();
		ViewBag.CategoryList = categories;

		return View(model);
	}

	[HttpPost]
	public async Task<IActionResult> Edit(BlogUpdateVM model)
	{
		var user = await userManager.FindByNameAsync(User.Identity.Name);

		var blog = await blogService.GetByIdAsync(model.Id);
		blog.Title = model.Title;
		blog.CategoryId = model.CategoryId;
		blog.Content = model.Content;

		if (model.Image != null)
		{
			var extension = Path.GetExtension(model.Image.FileName);
			var newImageName = Guid.NewGuid() + extension;
			var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", newImageName);
			var stream = new FileStream(location, FileMode.Create);
			model.Image.CopyTo(stream);
			blog.ImageUrl = Path.Combine("/WriterImageFiles/", newImageName);
		}

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
