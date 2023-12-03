using Blog.Entities.Abstract;

namespace Blog.Entities.Concrete;

public class Comment : BaseEntity
{
    public string UserName { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;
    public int BlogId { get; set; }
    public virtual Blog Blog { get; set; }
}
