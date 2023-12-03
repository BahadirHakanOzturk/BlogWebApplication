using Blog.Application.Contracts.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Presentation.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class CommentController : Controller
{
	private readonly ICommentService commentService;
	public CommentController(ICommentService commentService)
		=> this.commentService = commentService;

	public async Task<IActionResult> Index()
		=> View(await commentService.GetCommentListWithBlogAsync());

	public async Task<IActionResult> Delete(int id)
	{
		var value = await commentService.GetByIdAsync(id);
		await commentService.DeleteAsync(value);
		return RedirectToAction("Index");
	}
}
