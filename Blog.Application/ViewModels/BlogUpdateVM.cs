using Microsoft.AspNetCore.Http;

namespace Blog.Application.ViewModels;

public class BlogUpdateVM
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public string ImageUrl { get; set; }
    public IFormFile Image { get; set; }
    public int CategoryId { get; set; }
}
