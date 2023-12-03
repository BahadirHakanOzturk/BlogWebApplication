using Blog.Application.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Presentation.ViewComponents.Comment;

public class CommentList : ViewComponent
{
	private readonly ICommentService commentService;

	public CommentList(ICommentService commentService)
		=> this.commentService = commentService;

	public async Task<IViewComponentResult> InvokeAsync(int id)
		=> View(await commentService.GetAllByIdAsync(id));
}
