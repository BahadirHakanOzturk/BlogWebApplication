using Blog.Entities.Abstract;

namespace Blog.Entities.Concrete;

public class Contact : BaseEntity
{
    public string UserName { get; set; }
    public string Mail { get; set; }
    public string Subject { get; set; }
    public string Message { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;
}
