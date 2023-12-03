using Blog.Entities.Abstract;
using Blog.Entities.Concrete.User;

namespace Blog.Entities.Concrete;

public class Blog : BaseEntity
{
    public string Title { get; set; }
    public string Content { get; set; }
    public string? ImageUrl { get; set; }
    public DateTime CreateDate { get; set; }
    public int CategoryId { get; set; }
    public virtual Category Category { get; set; }
    public int UserId { get; set; }
    public virtual AppUser User { get; set; }
    public virtual ICollection<Comment> Comments { get; set; }
}
