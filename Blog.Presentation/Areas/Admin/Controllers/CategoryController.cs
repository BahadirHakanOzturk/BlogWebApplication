using AutoMapper;
using Blog.Application.Contracts.Services;
using Blog.Application.ViewModels;
using Blog.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace Blog.Presentation.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class CategoryController : Controller
{
	private readonly ICategoryService categoryService;
	private readonly IMapper mapper;

	public CategoryController(ICategoryService categoryService, IMapper mapper)
	{
		this.categoryService = categoryService;
		this.mapper = mapper;
	}

	public async Task<IActionResult> Index(int page = 1)
	{
		var categories = await categoryService.GetAllAsync();
		return View(categories.ToPagedList(page, 3));
	}

	public IActionResult Add()
		=> View();

	[HttpPost]
	public async Task<IActionResult> Add(CategoryAddVM model)
	{
		if (ModelState.IsValid)
		{
			var newEntity = mapper.Map<Category>(model);
			await categoryService.AddAsync(newEntity);
			return RedirectToAction("Index", "Category");
		}
		else
		{
			return View(model);
		}		
	}

	public async Task<IActionResult> Delete(int id)
	{
		var value = await categoryService.GetByIdAsync(id);
		await categoryService.DeleteAsync(value);
		return RedirectToAction("Index");
	}
}
