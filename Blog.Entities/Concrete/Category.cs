using Blog.Entities.Abstract;

namespace Blog.Entities.Concrete;

public class Category : BaseEntity
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public virtual ICollection<Blog> Blogs { get; set; }
}
