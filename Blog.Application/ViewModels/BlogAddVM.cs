using Blog.Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Blog.Application.ViewModels;

public class BlogAddVM
{
	public string Title { get; set; }
	public string Content { get; set; }
	public string? ImageUrl { get; set; }
	public int CategoryId { get; set; }
    public List<Category> CategoryList { get; set; }
    public IFormFile Image { get; set; }

}
