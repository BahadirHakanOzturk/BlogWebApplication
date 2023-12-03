using AutoMapper;
using Blog.Application.Contracts.Services;
using Blog.Application.ViewModels;
using Blog.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Presentation.Controllers;

[AllowAnonymous]
public class CommentController : Controller
{
	private readonly ICommentService commentService;
	private readonly IMapper mapper;
	public CommentController(ICommentService commentService, IMapper mapper)
	{
		this.commentService = commentService;
		this.mapper = mapper;
	}

	[HttpPost]
	public async Task<IActionResult> Add(CommentVM model)
	{
		var newComment = mapper.Map<Comment>(model);
		await commentService.AddAsync(newComment);
		return Json(model);
	}
}
