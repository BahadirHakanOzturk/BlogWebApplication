using Blog.Entities.Abstract;

namespace Blog.Entities.Concrete;

public class Notification : BaseEntity
{
    public string Type { get; set; }
    public string TypeSymbol { get; set; }
    public string Details { get; set; }
    public DateTime Date { get; set; }
    public string Color { get; set; }
}
